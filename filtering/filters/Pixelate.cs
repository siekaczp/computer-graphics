namespace filtering {
  class Pixelate : IFilter {
    public int PixelSize {
      get; set;
    }

    public Pixelate(int pixelSize) => PixelSize = pixelSize;

    public void Apply(byte[] rgbValues, BitmapInfo bitmapInfo) {
      for (int y = 0; y < bitmapInfo.height; y += PixelSize) {
        for (int x = 0; x < bitmapInfo.width; x += PixelSize) {
          int sumB = 0;
          int sumG = 0;
          int sumR = 0;

          int count = 0;
          for (int py = 0; py < PixelSize && y + py < bitmapInfo.height; py++) {
            for (int px = 0; px < PixelSize && x + px < bitmapInfo.width; px++) {
              int index = bitmapInfo.stride * (y + py) + 3 * (x + px);
              sumB += rgbValues[index];
              sumG += rgbValues[index + 1];
              sumR += rgbValues[index + 2];
              count++;
            }
          }

          sumB /= count;
          sumG /= count;
          sumR /= count;

          for (int py = 0; py < PixelSize && y + py < bitmapInfo.height; py++) {
            for (int px = 0; px < PixelSize && x + px < bitmapInfo.width; px++) {
              int index = bitmapInfo.stride * (y + py) + 3 * (x + px);
              rgbValues[index] = (byte) sumB;
              rgbValues[index + 1] = (byte) sumG;
              rgbValues[index + 2] = (byte) sumR;
            }
          }
        }
      }
    }
  }
}
