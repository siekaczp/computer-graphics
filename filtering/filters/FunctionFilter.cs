using System;
using System.Drawing;

namespace filtering {
  public class FunctionFilter : IFilter {
    private readonly Func<int, int> channelFunction;
    private readonly Func<Color, Color> colorFunction;
    private readonly FilterType filterType;

    private enum FilterType {
      channel,
      color
    }

    public FunctionFilter(Func<int, int> function) {
      channelFunction = function;
      filterType = FilterType.channel;
    }

    public FunctionFilter(Func<Color, Color> function) {
      colorFunction = function;
      filterType = FilterType.color;
    }

    public void Apply(byte[] rgbValues, BitmapInfo bitmapInfo) {
      if (filterType == FilterType.channel) {
        ChannelApply(rgbValues, bitmapInfo);
      } else {
        ColorApply(rgbValues, bitmapInfo);
      }
    }

    private void ChannelApply(byte[] rgbValues, BitmapInfo bitmapInfo) {
      int i = 0;
      for (int y = 0; y < bitmapInfo.height; y++) {
        for (int x = 0; x < 3 * bitmapInfo.width; x++) {
          rgbValues[i + x] = (byte) channelFunction(rgbValues[i + x]);
        }
        i += bitmapInfo.stride;
      }
    }

    private void ColorApply(byte[] rgbValues, BitmapInfo bitmapInfo) {
      int i = 0;
      for (int y = 0; y < bitmapInfo.height; y++) {
        for (int x = 0; x < bitmapInfo.width; x++) {
          int j = i + 3 * x;
          Color inputColor = Color.FromArgb(rgbValues[j + 2], rgbValues[j + 1], rgbValues[j]);
          Color outputColor = colorFunction(inputColor);
          rgbValues[j] = outputColor.B;
          rgbValues[j + 1] = outputColor.G;
          rgbValues[j + 2] = outputColor.R;
        }
        i += bitmapInfo.stride;
      }
    }
  }
}
