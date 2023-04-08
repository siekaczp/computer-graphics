namespace rasterization {
  internal class CompositeShape<T> : Shape where T : Shape {
    protected readonly List<T> shapes = new();

    public void Clear() => shapes.Clear();

    public void Add(T shape) => shapes.Add(shape);

    public override void Draw(byte[] rgbValues, int width, int height, int stride) {
      foreach (var shape in shapes) {
        shape.Draw(rgbValues, width, height, stride);
      }
    }
  }
}
