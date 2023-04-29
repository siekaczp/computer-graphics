using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Xml;

namespace rasterization {
  public record ImageByteArray {
    public byte[] RgbValues { get; init; } = null!;
    public int Width { get; init; }
    public int Height { get; init; }
    public int Stride { get; init; }

    private ImageByteArray() { }

    public ImageByteArray(Bitmap image) {
      Width = image.Width;
      Height = image.Height;

      System.Drawing.Rectangle rect = new(0, 0, Width, Height);
      BitmapData bmpData = image.LockBits(rect, ImageLockMode.ReadWrite, image.PixelFormat);
      Stride = bmpData.Stride;

      int bytes = Math.Abs(Stride) * Height;
      RgbValues = new byte[bytes];

      Marshal.Copy(bmpData.Scan0, RgbValues, 0, bytes);
      image.UnlockBits(bmpData);
    }

    public void FillBitmap(Bitmap image) {
      if (image.Width != Width || image.Height != Height)
        throw new ArgumentException();

      System.Drawing.Rectangle rect = new(0, 0, Width, Height);
      BitmapData bmpData = image.LockBits(rect, ImageLockMode.ReadWrite, image.PixelFormat);

      if (bmpData.Stride != Stride)
        throw new ArgumentException();

      Marshal.Copy(RgbValues, 0, bmpData.Scan0, RgbValues.Length);
      image.UnlockBits(bmpData);
    }

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

    public XmlElement ToXmlElement(XmlDocument doc) {
      XmlElement element = doc.CreateElement("Image");
      element.SetAttribute("RgbValues", Convert.ToBase64String(RgbValues));
      element.SetAttribute("Width", Width.ToString());
      element.SetAttribute("Height", Height.ToString());
      element.SetAttribute("Stride", Stride.ToString());
      return element;
    }

    public static ImageByteArray? FromXml(XmlElement element) {
      if (!int.TryParse(element.GetAttribute("Width"), out int width)
        || !int.TryParse(element.GetAttribute("Height"), out int height)
        || !int.TryParse(element.GetAttribute("Stride"), out int stride))
        return null;

      string valuesString = element.GetAttribute("RgbValues");
      if (valuesString == "")
        return null;
      try {
        byte[] values = Convert.FromBase64String(valuesString);
        if (values.Length != stride * height)
          return null;

        return new() {
          RgbValues = values,
          Width = width,
          Height = height,
          Stride = stride
        };
      } catch (FormatException) {
        return null;
      }
    }
  }
}
