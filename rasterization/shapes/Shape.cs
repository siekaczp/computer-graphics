namespace rasterization {
  internal abstract class Shape {
    public Color Color { get; set; }
    public int Thickness { get; set; }

    public Shape() {
      Color = Color.Black;
      Thickness = 1;
    }

    public abstract void Draw(byte[] rgbValues, int width, int height, int stride);

    protected void PutPixel(int x, int y, byte[] rgbValues, int width, int height, int stride) {
      if (x < 0 || x > width || y < 0 || y > height)
        return;
      int index = y * stride + 4 * x;
      rgbValues[index + 0] = Color.B;
      rgbValues[index + 1] = Color.G;
      rgbValues[index + 2] = Color.R;
      rgbValues[index + 3] = Color.A;
    }
  }
}
