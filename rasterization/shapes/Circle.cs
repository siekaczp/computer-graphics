namespace rasterization {
  internal class Circle : Shape {
    public Point Center { get; set; }
    public int Radius { get; set; }

    public Circle(Point center, int radius) {
      Center = center;
      Radius = radius;
    }

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
      double dist = Math.Sqrt(Math.Pow(point.X - Center.X, 2) + Math.Pow(point.Y - Center.Y, 2));
      return dist <= Radius + Epsilon && dist >= Radius - Epsilon ? this : null;
    }
  }
}