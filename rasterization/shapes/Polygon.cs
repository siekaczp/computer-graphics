﻿namespace rasterization {
  class Polygon : CompositeShape<Line> {
    public Polygon(List<Point> points) {
      if (points.Count < 3)
        return;

      Point point1 = points[0];
      Point point2 = new();

      for (int i = 1; i < points.Count; i++) {
        point2 = points[i];
        shapes.Add(new Line(point1, point2));
        point1 = point2;
      }

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
      // TODO: add corner cases
      Line lastLine = shapes.Last();
      if (lastLine == null) {
        shapes.Add(line);
        return;
      }

      lastLine.EndPoint = line.StartPoint;
      shapes.Add(line);

      Line firstLine = shapes[0];
      shapes.Add(new Line(line.EndPoint, firstLine.StartPoint));
    }
  }
}
