using System.Xml;

namespace rasterization {
  public class BezierCurve : Shape {
    private static readonly double Step = 0.02;
    private static readonly List<Func<double, double>> BernstanPolynomials = new() {
      t => Math.Pow(1 - t, 3),
      t => 3 * t * Math.Pow(1 - t, 2),
      t => 3 * Math.Pow(t, 2) * (1 - t),
      t => Math.Pow(t ,3),
    };

    public static Shape Marker(Point p) => new Circle(p, 4);

    private Point center = new(0, 0);

    public Point[] ControlPoints { get; init; }

    public BezierCurve(List<Point> controlPoints) {
      if (controlPoints.Count != 4) {
        ControlPoints = Array.Empty<Point>();
        return;
      }

      ControlPoints = controlPoints.ToArray();

      foreach (var controlPoint in controlPoints) {
        center.X += controlPoint.X;
        center.Y += controlPoint.Y;
      }
    }

    public override Shape? CheckColision(Point point) {
      for (double t = 0; t < 1 + Step; t += Step) {
        double sumX = 0;
        double sumY = 0;

        for (int i = 0; i < 4; i++) {
          double c = BernstanPolynomials[i](t);
          sumX += c * ControlPoints[i].X;
          sumY += c * ControlPoints[i].Y;
        }

        int sumXi = (int) sumX;
        int sumYi = (int) sumY;
        if ((point.X - sumXi) * (point.X - sumXi) + (point.Y - sumYi) * (point.Y - sumYi) <= Epsilon * Epsilon)
          return this;
      }

      return null;
    }

    public override void Draw(ImageByteArray imageByteArray, bool antialiasing) {
      Line temp;
      Point lastPoint = ControlPoints[0];

      for (double t = Step; t < 1 + Step; t += Step) {
        double sumX = 0;
        double sumY = 0;

        for (int i = 0; i < 4; i++) {
          double c = BernstanPolynomials[i](t);
          sumX += c * ControlPoints[i].X;
          sumY += c * ControlPoints[i].Y;
        }

        Point newPoint = new((int) sumX, (int) sumY);
        temp = new Line(lastPoint, newPoint) {
          Color = Color,
          Thickness = Thickness
        };
        temp.Draw(imageByteArray, antialiasing);
        lastPoint = newPoint;
      }
    }

    public override bool Edit(Point position, int dx, int dy) {
      for (int i = 0; i < 4; i++) {
        if ((ControlPoints[i].X - position.X) * (ControlPoints[i].X - position.X)
          + (ControlPoints[i].Y - position.Y) * (ControlPoints[i].Y - position.Y) < Epsilon * Epsilon) {
          ControlPoints[i].X += dx;
          ControlPoints[i].Y += dy;
          center.X += dx;
          center.Y += dy;
          return true;
        }
      }

      return false;
    }

    public override Point GetCenter() => new Point(center.X / 4, center.Y / 4);

    public override void Move(int dx, int dy) {
      for (int i = 0; i < 4; i++) {
        ControlPoints[i].X += dx;
        ControlPoints[i].Y += dy;
      }

      center.X += 4 * dx;
      center.Y += 4 * dy;
    }

    public override XmlElement ToXmlElement(XmlDocument doc) {
      XmlElement element = CreateXmlElement(doc, "BezierCurve");

      for (int i = 0; i < 4; i++) {
        element.SetAttribute($"ControlPoint{i}X", ControlPoints[i].X.ToString());
        element.SetAttribute($"ControlPoint{i}Y", ControlPoints[i].Y.ToString());
      }

      return element;
    }

    public static BezierCurve? FromXml(XmlElement element) {
      List<Point> points = new();

      for (int i = 0; i < 4; i++) {
        if (!int.TryParse(element.GetAttribute($"ControlPoint{i}X"), out int x))
          return null;
        if (!int.TryParse(element.GetAttribute($"ControlPoint{i}Y"), out int y))
          return null;
        points.Add(new Point(x, y));
      }

      BezierCurve newCurve = new(points);
      newCurve.SetAttributesFromXml(element);
      return newCurve;
    }
  }
}
