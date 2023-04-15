using System.Net;

namespace rasterization {
  class Polygon : CompositeShape<Line> {
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

    override public Shape? CheckColision(Point point) {
      foreach (var line in shapes) {
        if (line.CheckColision(point) != null)
          return this;
      }

      return null;
    }

    new public void Add(Line line) {
      if (shapes.Count == 0) {
        shapes.Add(line);
        centerSum = shapes[0].GetCenter();
      } else if (shapes.Count == 1) {
        shapes.Add(new Line(shapes[0].EndPoint, line.StartPoint));
        shapes.Add(line);
        shapes.Add(new Line(line.EndPoint, shapes[0].StartPoint));
        centerSum.X += shapes[1].GetCenter().X + shapes[2].GetCenter().X + shapes[3].GetCenter().X;
        centerSum.Y += shapes[1].GetCenter().Y + shapes[2].GetCenter().Y + shapes[3].GetCenter().Y;
      }

      centerSum.X -= shapes[0].GetCenter().X;
      centerSum.Y -= shapes[0].GetCenter().Y;
      shapes[0].StartPoint = line.EndPoint;
      centerSum.X += shapes[0].GetCenter().X;
      centerSum.Y += shapes[0].GetCenter().Y;

      centerSum.X -= shapes.Last().GetCenter().X;
      centerSum.Y -= shapes.Last().GetCenter().Y;
      shapes.Last().EndPoint = line.StartPoint;
      centerSum.X += shapes.Last().GetCenter().X;
      centerSum.Y += shapes.Last().GetCenter().Y;

      shapes.Add(line);
      centerSum.X += line.GetCenter().X;
      centerSum.Y += line.GetCenter().Y;
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
  }
}
