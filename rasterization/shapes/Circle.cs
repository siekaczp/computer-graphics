namespace rasterization {
  internal class Circle : Shape {
    public Point Center { get; set; }
    public int Radius { get; set; }

    public Circle(Point center, int radius) {
      Center = center;
      Radius = radius;
    }

    public override void Draw(byte[] rgbValues, int width, int height, int stride) {
      int dE = 3;
      int dSE = 5 - 2 * Radius;
      int d = 1 - Radius;
      int x = 0;
      int y = Radius;

      PutPixel(Center.X + x, Center.Y + y, rgbValues, width, height, stride);

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

        PutPixel(Center.X + x, Center.Y + y, rgbValues, width, height, stride);
        PutPixel(Center.X - x, Center.Y + y, rgbValues, width, height, stride);
        PutPixel(Center.X + x, Center.Y - y, rgbValues, width, height, stride);
        PutPixel(Center.X - x, Center.Y - y, rgbValues, width, height, stride);
        PutPixel(Center.X + y, Center.Y + x, rgbValues, width, height, stride);
        PutPixel(Center.X - y, Center.Y + x, rgbValues, width, height, stride);
        PutPixel(Center.X + y, Center.Y - x, rgbValues, width, height, stride);
        PutPixel(Center.X - y, Center.Y - x, rgbValues, width, height, stride);
      }
    }
  }
}