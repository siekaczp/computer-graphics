using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filtering {
  public abstract class Quantization : IFilter {
    abstract protected Color[] GetPallete(byte[] rgbValues, BitmapInfo bitmapInfo);

    public void Apply(byte[] rgbValues, BitmapInfo bitmapInfo) {
      Color[] pallete = GetPallete(rgbValues, bitmapInfo);

      Parallel.For(0, bitmapInfo.height, y => {
        Parallel.For(0, bitmapInfo.width, x => {
          int j = y * bitmapInfo.stride + 3 * x;
          Color newColor = FindNearestNeighborColor(Color.FromArgb(rgbValues[j + 2], rgbValues[j + 1], rgbValues[j]), pallete);
          rgbValues[j] = newColor.B;
          rgbValues[j + 1] = newColor.G;
          rgbValues[j + 2] = newColor.R;
        });
      });
    }

    private static Color FindNearestNeighborColor(Color color, Color[] mostPopular) {
      int minDist = int.MaxValue;
      Color chosen = color;

      foreach (Color candidate in mostPopular) {
        int dist = Distance(color, candidate);
        if (dist < minDist) {
          minDist = dist;
          chosen = candidate;
        }
      }

      return chosen;
    }

    private static int Distance(Color color, Color candidate) {
      int deltaR = color.R - candidate.R;
      int deltaG = color.G - candidate.G;
      int deltaB = color.B - candidate.B;

      return color.R + candidate.R < 256
        ? 2 * deltaR * deltaR + 4 * deltaG * deltaG + 3 * deltaB * deltaB
        : 3 * deltaR * deltaR + 4 * deltaG * deltaG + 2 * deltaB * deltaB;
    }
  }

  public class PopularityQuantization : Quantization {
    public int K {
      get; set;
    }

    public PopularityQuantization(int k) => K = k;

    protected override Color[] GetPallete(byte[] rgbValues, BitmapInfo bitmapInfo) {
      int[,,] histogram = new int[256, 256, 256];
      List<Color> mostPopular = new();
      KeyValuePair<Color, int> leastPopularOfBest = new(Color.Transparent, int.MinValue);

      int i = 0;
      for (int y = 0; y < bitmapInfo.height; y++) {
        for (int x = 0; x < bitmapInfo.width; x++) {
          int j = i + 3 * x;
          int r = rgbValues[j + 2];
          int g = rgbValues[j + 1];
          int b = rgbValues[j];
          histogram[r, g, b]++;
          Color newColor = Color.FromArgb(r, g, b);

          if ((histogram[r, g, b] >= leastPopularOfBest.Value || mostPopular.Count < K) && !mostPopular.Contains(newColor)) {
            mostPopular.Add(newColor);

            if (mostPopular.Count > K)
              mostPopular.Remove(leastPopularOfBest.Key);

            leastPopularOfBest = new KeyValuePair<Color, int>(Color.Transparent, int.MaxValue);
            foreach (var color in mostPopular) {
              if (histogram[color.R, color.G, color.B] < leastPopularOfBest.Value)
                leastPopularOfBest = new KeyValuePair<Color, int>(color, histogram[color.R, color.G, color.B]);
            }
          }
        }
        i += bitmapInfo.stride;
      }

      return mostPopular.ToArray();
    }
  }
}
