using System;
using System.Collections.Generic;
using System.Drawing;

namespace filtering {
  public readonly struct BitmapInfo {
    readonly public int width;
    readonly public int height;
    readonly public int stride;

    public BitmapInfo(int width, int height, int stride) {
      this.width = width;
      this.height = height;
      this.stride = stride;
    }
  }

  interface IFilter {
    void Apply(byte[] rgbValues, BitmapInfo bitmapInfo);
  }

  static class Filters {
    public static Dictionary<string, ConvolutionFilter> ConvolutionFilters {
      get;
    } = new Dictionary<string, ConvolutionFilter> {
        {
          "Blur",
          new ConvolutionFilter(new int[3, 3] {
            { 1, 1, 1 },
            { 1, 1, 1 },
            { 1, 1, 1 },
          }) {
            Divisor = 9,
          }
        },
        {
          "Gaussian blur",
          new ConvolutionFilter(new int[3, 3] {
          { 1, 2, 1 },
          { 2, 4, 2 },
          { 1, 2, 1 },
          }) {
            Divisor = 16
          }
        },
        {
          "Sharpen",
          new ConvolutionFilter(new int[3, 3] {
            {  0, -1,  0 },
            { -1,  5, -1 },
            {  0, -1,  0 },
          })
        },
        {
          "Edge detection",
          new ConvolutionFilter(new int[3, 3] {
          {  0, -1,  0 },
          { -1,  4, -1 },
          {  0, -1,  0 },
          }) {
            Offset = 128
          }
        },
        {
          "Emboss",
          new ConvolutionFilter(new int[3, 3] {
            { -1, 0, 1 },
            { -1, 1, 1 },
            { -1, 0, 1 },
          })
        },
      };

    private static readonly int brightnessInc = 50;
    private static readonly double a = 1.5;
    private static readonly double b = 255 / 2 * (1 - a);
    private static readonly double gamma = 2.2;

    public static Dictionary<string, FunctionFilter> FunctionFilters {
      get;
    } = new Dictionary<string, FunctionFilter> {
      {
        "Inversion",
        new FunctionFilter(x => 255 - x)
      },
      {
        "Brightness correction",
        new FunctionFilter(x => Math.Clamp(brightnessInc + x, 0, 255))
      },
      {
        "Contrast enhancment",
        new FunctionFilter(x => Math.Clamp((int) (a * x + b), 0, 255))
      },
      {
        "Gamma correction",
        new FunctionFilter(x => (int) (255 * Math.Pow((double) x / 255, gamma)))
      },
      {
        "Grayscale",
        new FunctionFilter(c => {
          int gray = (30 * c.R + 59 * c.G + 11 * c.B) / 100;
          return Color.FromArgb(gray, gray, gray);
        })
      }
    };

    public static Pixelate pixelateFilter = new(16);
    public static PopularityQuantization popularityQuantizationFilter = new(5);
    public static OrderedDithering ditheringFilter = new(2, 2);
  }
}
