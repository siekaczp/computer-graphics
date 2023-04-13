namespace rasterization {
  internal abstract class Shape {
    public const int Epsilon = 5;

    virtual public Color Color { get; set; }
    virtual public int Thickness { get; set; }

    public Shape() {
      Color = Color.Black;
      Thickness = 1;
    }

    public abstract void Draw(ImageByteArray imageByteArray, bool antialiasing);

    public abstract Shape? CheckColision(Point point);
  }
}
