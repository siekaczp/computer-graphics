using System.Net;

namespace _3d {
  internal class ImageByteArray {
    private readonly byte[] ImageBytes;
    private readonly int Width;
    private readonly int Height;
    private readonly int Stride;

    public ImageByteArray(byte[] imageBytes, Rectangle size, int stride) {
      ImageBytes = imageBytes;
      Width = size.Width;
      Height = size.Height;
      Stride = stride;
    }

    public void PutPixel(int x, int y, Color color) {
      if (x < 0 || x >= Width || y < 0 || y >= Height)
        return;

      int index = y * Stride + 3 * x;
      ImageBytes[index + 0] = color.B;
      ImageBytes[index + 1] = color.G;
      ImageBytes[index + 2] = color.R;
    }

    public Color GetPixel(int x, int y) {
      if (x < 0 || x >= Width || y < 0 || y >= Height)
        return Color.Empty;

      int index = y * Stride + 3 * x;
      return Color.FromArgb(
        ImageBytes[index + 2],
        ImageBytes[index + 1],
        ImageBytes[index + 0]
      );
    }

    public void DrawLine(Point start, Point end, Color color) {
      int x1 = start.X;
      int y1 = start.Y;
      int x2 = end.X;
      int y2 = end.Y;

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

        PutPixel(x, y, color);
        while (x < x2) {
          if (d < 0) {
            d += dE;
          } else {
            d += dNE;
            y += sign;
          }

          x++;
          PutPixel(x, y, color);
        }
      } else {
        int d = 2 * dx - dy;
        int dE = 2 * dx;
        int dNE = 2 * (dx - dy);

        PutPixel(x, y, color);
        while ((y < y2 && sign >= 0) || (y > y2 && sign < 0)) {
          if (d < 0) {
            d += dE;
          } else {
            d += dNE;
            x++;
          }

          y += sign;
          PutPixel(x, y, color);
        }
      }
    }

    public void DrawTriangle(Triangle triangle, Func<AffineVector, Point> Projection, Color color) {
      Point p1 = Projection(triangle.V1.p);
      Point p2 = Projection(triangle.V2.p);
      Point p3 = Projection(triangle.V3.p);

      Point[] vertices = { p1, p2, p3 };
      Array.Sort(vertices, (a, b) => a.Y - b.Y);

      Point topVertex = vertices[0];
      double invSlope1 = (double) (vertices[1].X - topVertex.X) / (vertices[1].Y - topVertex.Y);
      double invSlope2 = (double) (vertices[2].X - topVertex.X) / (vertices[2].Y - topVertex.Y);

      int startY = topVertex.Y;
      int endY = vertices[2].Y;

      for (int y = startY; y <= endY; y++) {
        if (y == vertices[1].Y) {
          topVertex = vertices[1];
          invSlope1 = vertices[2].Y == topVertex.Y ? 0 : (double) (vertices[2].X - topVertex.X) / (vertices[2].Y - topVertex.Y);
        }

        int startX = (int) (topVertex.X + (y - topVertex.Y) * invSlope1);
        int endX = (int) (vertices[0].X + (y - vertices[0].Y) * invSlope2);
        if (endX < startX)
          (startX, endX) = (endX, startX);

        for (int x = startX; x <= endX; x++) {
          PutPixel(x, y, color);
        }
      }
    }
  }
}
