namespace rasterization {
  internal class Line : Shape {
    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }

    public Line(Point startPoint, Point endPoint) {
      StartPoint = startPoint;
      EndPoint = endPoint;
    }

    public override void Draw(byte[] rgbValues, int width, int height, int stride) {
      throw new NotImplementedException();
    }
  }
}
