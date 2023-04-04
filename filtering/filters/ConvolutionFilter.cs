using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filtering {
  public class ConvolutionFilter : IFilter {
    private int[,] kernel;
    public int[,] Kernel {
      get => kernel;
      set {
        kernel = value;
        rows = kernel.GetLength(0);
        cols = kernel.GetLength(1);
      }
    }

    private int rows;
    private int cols;
    public int Rows => rows;
    public int Cols => cols;

    public int Divisor {
      get; set;
    }
    public int Offset {
      get; set;
    }
    public int AnchorX {
      get; set;
    }
    public int AnchorY {
      get; set;
    }

    public ConvolutionFilter(int[,] kernel) {
      Kernel = kernel;
      Divisor = 1;
      Offset = 0;
      AnchorY = rows / 2;
      AnchorX = cols / 2;
    }

    public void CalculateDivisor() {
      int newDivisor = Kernel.Cast<int>().Sum();
      if (newDivisor == 0)
        newDivisor = 1;
      Divisor = newDivisor;
    }

    public ConvolutionFilter Clone() => new(Kernel.Clone() as int[,]) {
      Divisor = Divisor,
      Offset = Offset,
      AnchorX = AnchorX,
      AnchorY = AnchorY
    };

    public void Apply(byte[] rgbValues, BitmapInfo bitmapInfo) {
      byte[] newValues = new byte[rgbValues.Length];
      int anchorCorrectionX = AnchorX - cols / 2;
      int anchorCorrectionY = AnchorY - rows / 2;

      Parallel.For(0, bitmapInfo.height, y => {
        Parallel.For(0, bitmapInfo.width, x => {
          int sumB = 0;
          int sumG = 0;
          int sumR = 0;

          for (int kernelY = -(rows / 2); kernelY <= rows / 2; kernelY++) {
            for (int kernelX = -(cols / 2); kernelX <= cols / 2; kernelX++) {
              int sourceX = x - kernelX - anchorCorrectionX;
              int sourceY = y - kernelY - anchorCorrectionY;

              if (sourceX < 0)
                sourceX = 0;
              if (sourceX >= bitmapInfo.width)
                sourceX = bitmapInfo.width - 1;
              if (sourceY < 0)
                sourceY = 0;
              if (sourceY >= bitmapInfo.height)
                sourceY = bitmapInfo.height - 1;

              int index = sourceY * bitmapInfo.stride + 3 * sourceX;
              int kernelValue = Kernel[rows / 2 + kernelY, cols / 2 + kernelX];

              sumB += kernelValue * rgbValues[index];
              sumG += kernelValue * rgbValues[index + 1];
              sumR += kernelValue * rgbValues[index + 2];
            }
          }

          int i = y * bitmapInfo.stride + 3 * x;
          newValues[i] = (byte) Math.Clamp(sumB / Divisor + Offset, 0, 255);
          newValues[i + 1] = (byte) Math.Clamp(sumG / Divisor + Offset, 0, 255);
          newValues[i + 2] = (byte) Math.Clamp(sumR / Divisor + Offset, 0, 255);
        });
      });

      Array.Copy(newValues, rgbValues, rgbValues.Length);
    }
  }
}
