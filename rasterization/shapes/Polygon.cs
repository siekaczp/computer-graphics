using System.Xml;

namespace rasterization {
  public class Polygon : CompositeShape<Line> {
    private Color? fillColor = null;
    private ImageByteArray? fillImage = null;

    public Polygon(List<Point> points) {
      if (points.Count < 2)
        return;

      if (points.Count == 2) {
        shapes.Add(new Line(points[0], points[1]));
        centerSum = shapes[0].GetCenter();
        return;
      }

      Point point1 = points[0];
      Point point2 = new();

      for (int i = 1; i < points.Count; i++) {
        point2 = points[i];
        centerSum.X += (point1.X + point2.X) / 2;
        centerSum.Y += (point1.Y + point2.Y) / 2;
        shapes.Add(new Line(point1, point2));
        point1 = point2;
      }

      centerSum.X += (point2.X + points[0].X) / 2;
      centerSum.Y += (point2.Y + points[0].Y) / 2;
      shapes.Add(new Line(point2, points[0]));
    }

    public Polygon() { }

    public override void Draw(ImageByteArray imageByteArray, bool antialiasing) {
      if (fillColor is not null || fillImage is not null)
        Fill(imageByteArray);

      foreach (var shape in shapes)
        shape.Draw(imageByteArray, antialiasing);
    }

    public Color? GetFillColor() => fillColor;

    public void SetFill(Color color) {
      ClearFill();
      fillColor = color;
    }

    public void SetFill(Bitmap image) {
      ClearFill();
      fillImage = new ImageByteArray(image);
    }

    public void ClearFill() {
      fillImage = null;
      fillColor = null;
    }

    private class Edge {
      public int yMax;
      public double x;
      public double mInv;
    }

    private void Fill(ImageByteArray imageByteArray) {
      Dictionary<int, List<Edge>> ET = new();
      List<Edge> AET = new();

      int minX = int.MaxValue;
      int minY = int.MaxValue;

      foreach (var line in shapes) {
        int startX = line.StartPoint.Y > line.EndPoint.Y ? line.EndPoint.X : line.StartPoint.X;
        int endX = line.StartPoint.Y > line.EndPoint.Y ? line.StartPoint.X : line.EndPoint.X;
        int startY = line.StartPoint.Y < line.EndPoint.Y ? line.StartPoint.Y : line.EndPoint.Y;
        int endY = line.StartPoint.Y < line.EndPoint.Y ? line.EndPoint.Y : line.StartPoint.Y;

        if (startX < minX)
          minX = startX;
        if (startY < minY)
          minY = startY;

        Edge edge = new() {
          yMax = line.StartPoint.Y > line.EndPoint.Y ? line.StartPoint.Y : line.EndPoint.Y,
          x = startX,
          mInv = (double) (endY - startY) / (endX - startX)
        };

        if (ET.ContainsKey(startY))
          ET[startY].Add(edge);
        else
          ET[startY] = new() { edge };
      }

      int y = minY;
      while (AET.Count > 0 || ET.Count > 0) {
        if (!ET.TryGetValue(y, out List<Edge>? tempList))
          tempList = new();

        AET.AddRange(tempList);
        ET.Remove(y);
        AET = AET.OrderBy(edge => edge.x).ToList();

        int index = 0;
        if (AET.Count > 0) {
          bool fill = false;

          int x = (int) AET[index].x;
          while (index < AET.Count) {
            if (x == (int) AET[index].x) {
              fill = !fill;
              index++;
              continue;
            }
            x++;

            if (fill) {
              imageByteArray.PutPixel(x, y,
                fillImage is not null
                ? fillImage.GetPixel((x - minX) % fillImage.Width, (y - minY) % fillImage.Height)
                : (fillColor ?? Color.Transparent)
              );
            }
          }
        }

        y++;
        AET = AET.Where(edge => edge.yMax > y).ToList();
        AET.ForEach(edge => edge.x += 1 / edge.mInv);
      }
    }

    override public Shape? CheckColision(Point point) {
      foreach (var line in shapes) {
        if (line.CheckColision(point) != null)
          return this;
      }

      return null;
    }

    public override bool Edit(Point position, int dx, int dy) {
      int selectedI = -1;
      bool pointClicked = false;

      for (int i = 0; i < shapes.Count; i++) {
        Point startPoint = shapes[i].StartPoint;
        if (Math.Abs(startPoint.X - position.X) <= Epsilon && Math.Abs(startPoint.Y - position.Y) <= Epsilon) {
          selectedI = i;
          pointClicked = true;
          break;
        }
      }

      if (selectedI == -1) {
        for (int i = 0; i < shapes.Count; i++) {
          if (shapes[i].CheckColision(position) != null) {
            selectedI = i;
            break;
          }
        }
      }

      if (selectedI == -1)
        return false;

      Point newStartPoint = new(shapes[selectedI].StartPoint.X + dx, shapes[selectedI].StartPoint.Y + dy);

      shapes[selectedI].StartPoint = newStartPoint;
      if (selectedI != 0)
        shapes[selectedI - 1].EndPoint = newStartPoint;
      else
        shapes.Last().EndPoint = newStartPoint;

      if (!pointClicked) {
        Point newEndPoint = new(shapes[selectedI].EndPoint.X + dx, shapes[selectedI].EndPoint.Y + dy);

        shapes[selectedI].EndPoint = newEndPoint;
        if (selectedI != shapes.Count - 1)
          shapes[selectedI + 1].StartPoint = newEndPoint;
        else
          shapes[0].StartPoint = newEndPoint;

        centerSum.X += dx;
        centerSum.Y += dy;
      }

      centerSum.X += dx;
      centerSum.Y += dy;

      return true;
    }

    protected void SerializeFill(XmlDocument doc, XmlElement element) {
      if (fillColor is not null) {
        element.SetAttribute("FillColor", ColorTranslator.ToHtml(fillColor.Value));
        return;
      }

      if (fillImage is not null) {
        element.AppendChild(fillImage.ToXmlElement(doc));
      }
    }

    protected void DeserializeFill(XmlElement element) {
      string color = element.GetAttribute("FillColor");
      if (color != "") {
        fillColor = ColorTranslator.FromHtml(color);
        return;
      }

      XmlNode? childElement = element.FirstChild;
      if (childElement is not null) {
        fillImage = ImageByteArray.FromXml((XmlElement) childElement);
      }
    }

    public override XmlElement ToXmlElement(XmlDocument doc) {
      XmlElement element = CreateXmlElement(doc, "Polygon");

      SerializeFill(doc, element);
      element.SetAttribute("CenterSumX", centerSum.X.ToString());
      element.SetAttribute("CenterSumY", centerSum.Y.ToString());

      foreach (var shape in shapes)
        element.AppendChild(shape.ToXmlElement(doc));

      return element;
    }

    public static new Polygon? FromXml(XmlElement element) {
      Polygon polygon = new();
      polygon.SetAttributesFromXml(element);
      polygon.DeserializeFill(element);

      foreach (var innerElement in element.ChildNodes) {
        Line? newLine = Line.FromXml((XmlElement) innerElement);
        if (newLine is not null)
          polygon.Add(newLine);
      }

      return polygon;
    }
  }
}
