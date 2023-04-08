namespace rasterization {
  internal class Line : Shape {
    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }

    public Line(Point startPoint, Point endPoint) {
      StartPoint = startPoint;
      EndPoint = endPoint;
    }

    public override void Draw(byte[] rgbValues, int width, int height, int stride) {
      int x1 = StartPoint.X;
      int y1 = StartPoint.Y;
      int x2 = EndPoint.X;
      int y2 = EndPoint.Y;

      if (x1 > x2) {
        (x1, x2) = (x2, x1);
        (y1, y2) = (y2, y1);
      }

      int dx = x2 - x1;
      int dy = Math.Abs(y2 - y1);
      int sign = Math.Sign(y2 - y1);
      int x = x1, y = y1;

      if (dy <= dx) {
        int d = 2 * dy - dx;
        int dE = 2 * dy;
        int dNE = 2 * (dy - dx);

        PutPixel(x, y, rgbValues, width, height, stride);

        while (x < x2) {
          if (d < 0) {
            d += dE;
          } else {
            d += dNE;
            y += sign;
          }

          x++;

          PutPixel(x, y, rgbValues, width, height, stride);
        }
      } else {
        int d = 2 * dx - dy;
        int dE = 2 * dx;
        int dNE = 2 * (dx - dy);

        PutPixel(x, y, rgbValues, width, height, stride);

        while ((y < y2 && sign >= 0) || (y > y2 && sign < 0)) {
          if (d < 0) {
            d += dE;
          } else {
            d += dNE;
            x++;
          }

          y += sign;

          PutPixel(x, y, rgbValues, width, height, stride);
        }
      }
    }
  }
}
