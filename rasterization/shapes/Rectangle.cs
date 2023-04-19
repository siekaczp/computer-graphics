using System.Xml;

namespace rasterization {
  public class Rectangle : Polygon {
    private Point point1;
    public Point Point1 {
      get => point1;
      set {
        point1 = value;
        UpdateLines();
      }
    }

    private Point point2;
    public Point Point2 {
      get => point2;
      set {
        point2 = value;
        UpdateLines();
      }
    }

    private Point Point3 { get => new(Point1.X, Point2.Y); }
    private Point Point4 { get => new(Point2.X, Point1.Y); }

    public Rectangle(Point p1, Point p2) {
      point1 = p1;
      point2 = p2;

      shapes.Add(new Line(point1, Point3));
      shapes.Add(new Line(point1, Point4));
      shapes.Add(new Line(point2, Point3));
      shapes.Add(new Line(point2, Point4));
      centerSum.X = 2 * (point1.X + point2.X);
      centerSum.Y = 2 * (point1.Y + point2.Y);
    }

    private void UpdateLines() {
      shapes[0].StartPoint = Point1;
      shapes[0].EndPoint = Point3;
      shapes[1].StartPoint = Point1;
      shapes[1].EndPoint = Point4;
      shapes[2].StartPoint = Point2;
      shapes[2].EndPoint = Point3;
      shapes[3].StartPoint = Point2;
      shapes[3].EndPoint = Point4;
      centerSum.X = 2 * (point1.X + point2.X);
      centerSum.Y = 2 * (point1.Y + point2.Y);
    }

    public override bool Edit(Point position, int dx, int dy) {
      if (CheckColision(position) is null)
        return false;

      bool p1x = Math.Abs(point1.X - position.X) <= Epsilon;
      bool p1y = Math.Abs(point1.Y - position.Y) <= Epsilon;
      bool p2x = Math.Abs(point2.X - position.X) <= Epsilon;
      bool p2y = Math.Abs(point2.Y - position.Y) <= Epsilon;

      if (p1x && p1y) {
        point1 = new Point(point1.X + dx, point1.Y + dy);
      } else if (p2x && p2y) {
        point2 = new Point(point2.X + dx, point2.Y + dy);
      } else if (p1x && p2y) {
        point1 = new Point(point1.X + dx, point1.Y);
        point2 = new Point(point2.X, point2.Y + dy);
      } else if (p2x && p1y) {
        point1 = new Point(point1.X, point1.Y + dy);
        point2 = new Point(point2.X + dx, point2.Y);
      } else if (p1y) {
        point1 = new Point(point1.X, point1.Y + dy);
      } else if (p2x) {
        point2 = new Point(point2.X + dx, point2.Y);
      } else if (p2y) {
        point2 = new Point(point2.X, point2.Y + dy);
      } else if (p1x) {
        point1 = new Point(point1.X + dx, point1.Y);
      }

      UpdateLines();
      return true;
    }

    public override void Move(int dx, int dy) {
      Point1 = new Point(point1.X + dx, point1.Y + dy);
      Point2 = new Point(point2.X + dx, point2.Y + dy);
      UpdateLines();
    }

    public override XmlElement ToXmlElement(XmlDocument doc) {
      XmlElement element = CreateXmlElement(doc, "Rectangle");
      element.SetAttribute("Point1X", point1.X.ToString());
      element.SetAttribute("Point1Y", point1.Y.ToString());
      element.SetAttribute("Point2X", point2.X.ToString());
      element.SetAttribute("Point2Y", point2.Y.ToString());
      return element;
    }

    public static new Rectangle? FromXml(XmlElement element) {
      if (!int.TryParse(element.GetAttribute("Point1X"), out int point1X)
        || !int.TryParse(element.GetAttribute("Point1Y"), out int point1Y)
        || !int.TryParse(element.GetAttribute("Point2X"), out int point2X)
        || !int.TryParse(element.GetAttribute("Point2Y"), out int point2Y))
        return null;

      Rectangle newRectangle = new(new Point(point1X, point1Y), new Point(point2X, point2Y));
      newRectangle.SetAttributesFromXml(element);
      return newRectangle;
    }
  }
}
