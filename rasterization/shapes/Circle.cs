using System.Xml;

namespace rasterization {
  public class Circle : Shape {
    public Point Center { get; set; }
    public int Radius { get; set; }

    public Circle(Point center, int radius) {
      Center = center;
      Radius = radius;
    }

    public Circle(Point center, Point point) {
      int r = Distance(center, point);
      Center = center;
      Radius = r;
    }

    static public int Distance(Point p1, Point p2) => (int) Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));

    public override void Draw(ImageByteArray imageByteArray, bool antialiasing) {
      int dE = 3;
      int dSE = 5 - 2 * Radius;
      int d = 1 - Radius;
      int x = 0;
      int y = Radius;

      imageByteArray.PutPixel(Center.X + x, Center.Y + y, Color);

      while (y > x) {
        if (d < 0) {
          d += dE;
          dE += 2;
          dSE += 2;
        } else {
          d += dSE;
          dE += 2;
          dSE += 4;
          y--;
        }

        ++x;

        imageByteArray.PutPixel(Center.X + x, Center.Y + y, Color);
        imageByteArray.PutPixel(Center.X - x, Center.Y + y, Color);
        imageByteArray.PutPixel(Center.X + x, Center.Y - y, Color);
        imageByteArray.PutPixel(Center.X - x, Center.Y - y, Color);
        imageByteArray.PutPixel(Center.X + y, Center.Y + x, Color);
        imageByteArray.PutPixel(Center.X - y, Center.Y + x, Color);
        imageByteArray.PutPixel(Center.X + y, Center.Y - x, Color);
        imageByteArray.PutPixel(Center.X - y, Center.Y - x, Color);
      }
    }

    public override Shape? CheckColision(Point point) {
      int dist = Distance(point, Center);
      return dist <= Radius + Epsilon && dist >= Radius - Epsilon ? this : null;
    }

    public override Point GetCenter() => Center;

    public override void Move(int dx, int dy) {
      Center = new Point(Center.X + dx, Center.Y + dy);
    }

    public override bool Edit(Point position, int dx, int dy) {
      if (CheckColision(position) == null)
        return false;

      Radius = Distance(Center, position + new Size(dx, dy));
      return true;
    }

    public override XmlElement ToXmlElement(XmlDocument doc) {
      XmlElement element = CreateXmlElement(doc, "Circle");
      element.SetAttribute("CenterX", Center.X.ToString());
      element.SetAttribute("CenterY", Center.Y.ToString());
      element.SetAttribute("Radius", Radius.ToString());
      return element;
    }

    public static Circle? FromXml(XmlElement element) {
      if (!int.TryParse(element.GetAttribute("CenterX"), out int centerX)
        || !int.TryParse(element.GetAttribute("CenterY"), out int centerY)
        || !int.TryParse(element.GetAttribute("Radius"), out int radius))
        return null;

      Circle newCircle = new(new Point(centerX, centerY), radius);
      newCircle.SetAttributesFromXml(element);
      return newCircle;
    }
  }
}