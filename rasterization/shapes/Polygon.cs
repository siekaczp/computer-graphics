using System.Xml;

namespace rasterization {
  public class Polygon : CompositeShape<Line> {
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

    public override XmlElement ToXmlElement(XmlDocument doc) {
      XmlElement element = CreateXmlElement(doc, "Polygon");

      element.SetAttribute("CenterSumX", centerSum.X.ToString());
      element.SetAttribute("CenterSumY", centerSum.Y.ToString());

      foreach (var shape in shapes)
        element.AppendChild(shape.ToXmlElement(doc));

      return element;
    }

    public static new Polygon? FromXml(XmlElement element) {
      Polygon polygon = new();
      polygon.SetAttributesFromXml(element);

      foreach (var innerElement in element.ChildNodes) {
        Line? newLine = Line.FromXml((XmlElement) innerElement);
        if (newLine is not null)
          polygon.Add(newLine);
      }

      return polygon;
    }
  }
}
