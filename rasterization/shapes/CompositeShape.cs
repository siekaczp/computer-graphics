using System.Collections.ObjectModel;
using System.Xml;

namespace rasterization {
  public class CompositeShape<T> : Shape where T : Shape {
    protected readonly List<T> shapes = new();
    public ReadOnlyCollection<T> Shapes => shapes.AsReadOnly();

    private Color _color;
    public override Color Color {
      get => _color;
      set {
        _color = value;
        foreach (var shape in shapes)
          shape.Color = value;
      }
    }

    private int _thickness;
    public override int Thickness {
      get => _thickness;
      set {
        _thickness = value;
        foreach (var shape in shapes)
          shape.Thickness = value;
      }
    }

    protected Point centerSum = new(0, 0);

    public void Clear() => shapes.Clear();

    public void Add(T shape) {
      Point center = shape.GetCenter();
      centerSum.X += center.X;
      centerSum.Y += center.Y;
      shapes.Add(shape);
    }

    public void Remove(T shape) => shapes.Remove(shape);

    public override void Draw(ImageByteArray imageByteArray, bool antialiasing) {
      foreach (var shape in shapes)
        shape.Draw(imageByteArray, antialiasing);
    }

    public override Shape? CheckColision(Point point) {
      foreach (var shape in shapes) {
        if (shape.CheckColision(point) != null)
          return shape;
      }

      return null;
    }

    public override Point GetCenter() => new(centerSum.X / shapes.Count, centerSum.Y / shapes.Count);

    public override void Move(int dx, int dy) {
      foreach (var shape in shapes)
        shape.Move(dx, dy);

      centerSum.X += dx * shapes.Count;
      centerSum.Y += dy * shapes.Count;
    }

    public override bool Edit(Point position, int dx, int dy) {
      foreach (var shape in shapes)
        if (shape.Edit(position, dx, dy)) {
          centerSum.X += dx;
          centerSum.Y += dy;
          return true;
        }

      return false;
    }

    public override XmlElement ToXmlElement(XmlDocument doc) {
      XmlElement element = CreateXmlElement(doc, "CompositeShape");

      foreach (var shape in shapes)
        element.AppendChild(shape.ToXmlElement(doc));

      return element;
    }

    public static CompositeShape<Shape>? FromXml(XmlElement element) {
      CompositeShape<Shape> shape = new();
      shape.SetAttributesFromXml(element);

      foreach (var innerElement in element.ChildNodes) {
        XmlElement element1 = (XmlElement) innerElement;
        string qualifiedName = typeof(Shape).AssemblyQualifiedName!.Replace("Shape", element1.Name);
        Type? type = Type.GetType(qualifiedName);
        Shape? newShape = type?.GetMethod("FromXml")?.Invoke(null, new object[] { element1 }) as Shape;

        if (newShape is not null)
          shape.Add(newShape);
      }

      return shape;
    }
  }
}
