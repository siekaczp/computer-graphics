namespace rasterization {
  internal record ImageByteArray {
    public byte[] RgbValues { get; init; } = null!;
    public int Width { get; init; }
    public int Height { get; init; }
    public int Stride { get; init; }

    public void PutPixel(int x, int y, Color color) {
      if (x < 0 || x >= Width || y < 0 || y >= Height)
        return;

      int index = y * Stride + 4 * x;
      RgbValues[index + 0] = color.B;
      RgbValues[index + 1] = color.G;
      RgbValues[index + 2] = color.R;
      RgbValues[index + 3] = color.A;
    }

    public Color GetPixel(int x, int y) {
      if (x < 0 || x >= Width || y < 0 || y >= Height)
        return Color.Transparent;

      int index = y * Stride + 4 * x;
      return Color.FromArgb(
        RgbValues[index + 3],
        RgbValues[index + 2],
        RgbValues[index + 1],
        RgbValues[index + 0]
      );
    }
  }
}
