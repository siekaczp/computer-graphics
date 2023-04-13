namespace rasterization {
  internal class CompositeShape<T> : Shape where T : Shape {
    protected readonly List<T> shapes = new();
    private Color _color;
    public override Color Color {
      get => _color;
      set {
        _color = value;
        foreach (var shape in shapes) {
          shape.Color = value;
        }
      }
    }

    private int _thickness;
    public override int Thickness {
      get => _thickness;
      set {
        _thickness = value;
        foreach (var shape in shapes) {
          shape.Thickness = value;
        }
      }
    }

    public void Clear() => shapes.Clear();

    public void Add(T shape) => shapes.Add(shape);

    public void Remove(T shape) => shapes.Remove(shape);

    public override void Draw(ImageByteArray imageByteArray, bool antialiasing) {
      foreach (var shape in shapes) {
        shape.Draw(imageByteArray, antialiasing);
      }
    }

    public override Shape? CheckColision(Point point) {
      foreach (var shape in shapes) {
        if (shape.CheckColision(point) != null)
          return shape;
      }

      return null;
    }
  }
}
