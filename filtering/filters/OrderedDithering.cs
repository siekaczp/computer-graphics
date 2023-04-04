using System;

namespace filtering {
  public class OrderedDithering : IFilter {
    public int ColorsPerChannel {
      get; set;
    }

    private int mapSize;
    public int MapSize {
      get => mapSize;
      set {
        mapSize = value < 2 || value > 6 || value == 5 ? 2 : value;
        SetBayerMatrix(mapSize);
      }
    }

    private static readonly byte[,] Bayer2 = new byte[,] {
      { 0, 2 }, { 3, 1 }
    };
    private static readonly byte[,] Bayer3 = new byte[,] {
      { 2, 6, 3 }, { 5, 0, 8 }, { 1, 7, 4 }
    };
    private static readonly byte[,] Bayer4 = new byte[,] {
      { 0, 8, 2, 10 }, { 12, 4, 14, 6 }, { 3, 11, 1, 9 }, { 15, 7, 13, 5 }
    };
    private static readonly byte[,] Bayer6 = new byte[,] {
      { 8, 24, 12, 10, 26, 14 },
      { 20, 0, 32, 22, 2, 34 },
      { 4, 28, 16, 6, 30, 18 },
      { 11, 27, 15, 9, 25, 13 },
      { 23, 3, 35, 21, 1, 33 },
      { 7, 31, 19, 5, 29, 17 }
    };

    private byte[,] BayerMatrix;

    private void SetBayerMatrix(int size) {
      BayerMatrix = size switch {
        3 => Bayer3.Clone() as byte[,],
        4 => Bayer4.Clone() as byte[,],
        6 => Bayer6.Clone() as byte[,],
        _ => Bayer2.Clone() as byte[,],
      };

      for (int i = 0; i < size; i++) {
        for (int j = 0; j < size; j++) {
          BayerMatrix[i, j] = (byte) (BayerMatrix[i, j] * 256 / (size * size));
        }
      }
    }


    public OrderedDithering(int colorsPerChannel, int mapSize) {
      ColorsPerChannel = colorsPerChannel;
      MapSize = mapSize;
    }

    public void Apply(byte[] rgbValues, BitmapInfo bitmapInfo) {
      int i = 0;

      for (int y = 0; y < bitmapInfo.height; y++) {
        int row = y % mapSize;
        int j = i;
        for (int x = 0; x < bitmapInfo.width; x++) {
          int col = x % mapSize;

          rgbValues[j + 0] = GetColor(rgbValues[j + 0], BayerMatrix[col, row]);
          rgbValues[j + 1] = GetColor(rgbValues[j + 1], BayerMatrix[col, row]);
          rgbValues[j + 2] = GetColor(rgbValues[j + 2], BayerMatrix[col, row]);

          j += 3;
        }
        i += bitmapInfo.stride;
      }
    }

    private byte GetColor(byte color, int threshhold) {
      double step = 255 / (double) (ColorsPerChannel - 1);
      double res = ((double) color / 256) * (ColorsPerChannel - 1);
      double x = Math.Floor(res);
      double y = res - x;
      if (y * 256 >= threshhold)
        x++;
      return (byte) Math.Round(step * x);
    }
  }
}
