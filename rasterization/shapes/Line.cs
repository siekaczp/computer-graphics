using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace rasterization {
  internal class Line : Shape {
    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }

    public Line(Point startPoint, Point endPoint) {
      StartPoint = startPoint;
      EndPoint = endPoint;
    }

    public static Color Lerp(Color s, Color t, double k) {
      var bk = (1 - k);
      var a = s.A * bk + t.A * k;
      var r = s.R * bk + t.R * k;
      var g = s.G * bk + t.G * k;
      var b = s.B * bk + t.B * k;
      return Color.FromArgb((int) a, (int) r, (int) g, (int) b);
    }

    private static double Cov(double d, double r) => d <= r
      ? (Math.Acos(d / r) - d / (r * r) * Math.Sqrt(r * r - d * d)) / Math.PI
      : 0;

    private bool IntensifyPixel(int x, int y, ImageByteArray imageByteArray, double d) {
      double r = 0.5;
      double w = (double) Thickness / 2;
      double cov = (w <= d) ? Cov(d - w, r) : 1 - Cov(w - d, r);
      if (cov > 0) {
        imageByteArray.PutPixel(x, y, Lerp(imageByteArray.GetPixel(x, y), Color, cov));
        return true;
      }
      return false;
    }

    public override void Draw(ImageByteArray imageByteArray, bool antialiasing) {
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

      double invDenom = 1 / (2 * Math.Sqrt(dx * dx + dy * dy));

      if (dy <= dx) {
        double two_dx_invDenom = 2 * dx * invDenom;
        int d = 2 * dy - dx;
        int dE = 2 * dy;
        int dNE = 2 * (dy - dx);

        if (antialiasing) {
          IntensifyPixel(x, y, imageByteArray, 0);
          for (int i = 1; IntensifyPixel(x, y + i, imageByteArray, i * two_dx_invDenom); i++)
            ;
          for (int i = 1; IntensifyPixel(x, y - i, imageByteArray, i * two_dx_invDenom); i++)
            ;
        } else {
          imageByteArray.PutPixel(x, y, Color);
          for (int i = 1; i < Thickness / 2; i++) {
            imageByteArray.PutPixel(x, y + i, Color);
            imageByteArray.PutPixel(x, y - i, Color);
          }
        }

        while (x < x2) {
          int two_v_dx;

          if (d < 0) {
            two_v_dx = d + dx;
            d += dE;
          } else {
            two_v_dx = d - dx;
            d += dNE;
            y += sign;
          }

          x++;

          if (antialiasing) {
            IntensifyPixel(x, y, imageByteArray, two_v_dx * invDenom);
            for (int i = 1; IntensifyPixel(x, y - i, imageByteArray, i * two_dx_invDenom + sign * two_v_dx * invDenom); i++)
              ;
            for (int i = 1; IntensifyPixel(x, y + i, imageByteArray, i * two_dx_invDenom - sign * two_v_dx * invDenom); i++)
              ;
          } else {
            imageByteArray.PutPixel(x, y, Color);
            for (int i = 1; i < Thickness / 2; i++) {
              imageByteArray.PutPixel(x, y + i, Color);
              imageByteArray.PutPixel(x, y - i, Color);
            }
          }
        }
      } else {
        double two_dy_invDenom = 2 * dy * invDenom;
        int d = 2 * dx - dy;
        int dE = 2 * dx;
        int dNE = 2 * (dx - dy);

        if (antialiasing) {
          IntensifyPixel(x, y, imageByteArray, 0);
          for (int i = 1; IntensifyPixel(x + i, y, imageByteArray, i * two_dy_invDenom); i++)
            ;
          for (int i = 1; IntensifyPixel(x - i, y, imageByteArray, i * two_dy_invDenom); i++)
            ;
        } else {
          imageByteArray.PutPixel(x, y, Color);
          for (int i = 1; i < Thickness / 2; i++) {
            imageByteArray.PutPixel(x + i, y, Color);
            imageByteArray.PutPixel(x - i, y, Color);
          }
        }

        while ((y < y2 && sign >= 0) || (y > y2 && sign < 0)) {
          int two_v_dy;

          if (d < 0) {
            two_v_dy = d + dy;
            d += dE;
          } else {
            two_v_dy = d - dy;
            d += dNE;
            x++;
          }

          y += sign;

          if (antialiasing) {
            IntensifyPixel(x, y, imageByteArray, two_v_dy * invDenom);
            for (int i = 1; IntensifyPixel(x - i, y, imageByteArray, i * two_dy_invDenom + two_v_dy * invDenom); i++)
              ;
            for (int i = 1; IntensifyPixel(x + i, y, imageByteArray, i * two_dy_invDenom - two_v_dy * invDenom); i++)
              ;
          } else {
            imageByteArray.PutPixel(x, y, Color);
            for (int i = 1; i < Thickness / 2; i++) {
              imageByteArray.PutPixel(x + i, y, Color);
              imageByteArray.PutPixel(x - i, y, Color);
            }
          }
        }
      }
    }

    public override Shape? CheckColision(Point point) {
      int dx = EndPoint.X - StartPoint.X;
      int dy = EndPoint.Y - StartPoint.Y;
      int t = (point.X - StartPoint.X) * dx + (point.Y - StartPoint.Y) * dy;
      int d2 = dx * dx + dy * dy;

      if (t < 0) {
        dx = point.X - StartPoint.X;
        dy = point.Y - StartPoint.Y;
      } else if (t > d2) {
        dx = point.X - EndPoint.X;
        dy = point.Y - EndPoint.Y;
      } else {
        dx = point.X - StartPoint.X - (int) ((double) t / d2 * dx);
        dy = point.Y - StartPoint.Y - (int) ((double) t / d2 * dy);
      }

      return dx * dx + dy * dy <= Epsilon * Epsilon ? this : null;
    }

    public override Point GetCenter() => new Point((StartPoint.X + EndPoint.X) / 2, (StartPoint.Y + EndPoint.Y) / 2);

    public override void Move(int dx, int dy) {
      StartPoint = new Point(StartPoint.X + dx, StartPoint.Y + dy);
      EndPoint = new Point(EndPoint.X + dx, EndPoint.Y + dy);
    }

    public override bool Edit(Point position, int dx, int dy) {
      if (Math.Abs(position.X - StartPoint.X) <= Epsilon && Math.Abs(position.Y - StartPoint.Y) <= Epsilon) {
        StartPoint = new Point(StartPoint.X + dx, StartPoint.Y + dy);
        return true;
      } else if (Math.Abs(position.X - EndPoint.X) <= Epsilon && Math.Abs(position.Y - EndPoint.Y) <= Epsilon) {
        EndPoint = new Point(EndPoint.X + dx, EndPoint.Y + dy);
        return true;
      } else if (CheckColision(position) != null) {
        Move(dx, dy);
        return true;
      }

      return false;
    }
  }
}
