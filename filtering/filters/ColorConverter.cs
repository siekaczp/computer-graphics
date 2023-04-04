using System;

namespace filtering {
  static class ColorConverter {
    private class ColorConvertingFilter : IFilter {
      private readonly Func<byte, byte, byte, Tuple<byte, byte, byte>> func;

      public ColorConvertingFilter(Func<byte, byte, byte, Tuple<byte, byte, byte>> func) {
        this.func = func;
      }

      public void Apply(byte[] rgbValues, BitmapInfo bitmapInfo) {
        for (int y = 0; y < bitmapInfo.height; y++) {
          for (int x = 0; x < 3 * bitmapInfo.width; x += 3) {
            int i = y * bitmapInfo.stride + x;
            var result = func(rgbValues[i + 2], rgbValues[i + 1], rgbValues[i]);
            rgbValues[i + 2] = result.Item1;
            rgbValues[i + 1] = result.Item2;
            rgbValues[i] = result.Item3;
          }
        }
      }
    }

    static public IFilter ToRGB() {
      return new ColorConvertingFilter((Y, Cb, Cr) => {
        double r = Y + 1.403 * (Cr - 128);
        double g = Y + (-0.344) * (Cb - 128) + (-0.714) * (Cr - 128);
        double b = Y + 1.773 * (Cb - 128);
        return new Tuple<byte, byte, byte>((byte) r, (byte) g, (byte) b);
      });
    }

    static public IFilter ToYCbCr() {
      return new ColorConvertingFilter((r, g, b) => {
        double Y = 0.299 * r + 0.587 * g + 0.114 * b;
        double Cb = (-0.169 * r) + (-0.331 * g) + 0.5 * b + 128;
        double Cr = 0.5 * r + (-0.419 * g) + (-0.081 * b) + 128;
        return new Tuple<byte, byte, byte>((byte) Y, (byte) Cb, (byte) Cr);
      });
    }
  }
}
