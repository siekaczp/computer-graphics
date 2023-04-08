namespace rasterization {
  internal class Circle : Shape {
    public Point Center { get; set; }
    public int Radius { get; set; }

    public Circle(Point center, int radius) {
      Center = center;
      Radius = radius;
    }

    public override void Draw(byte[] rgbValues, int width, int height, int stride) {
      throw new NotImplementedException();
    }
  }
}