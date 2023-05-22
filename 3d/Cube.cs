namespace _3d {
  internal class Cube {
    private Vector3D _location;
    public Vector3D Location {
      get => _location;
      set {
        Vector3D translation = value - _location;
        vertices = vertices.Select(vertex => vertex + translation).ToArray();
        _location = value;
      }
    }

    private double _size;
    public double Size {
      get => _size;
      set {
        double scale = value / _size;
        vertices = vertices.Select(vertex => scale * vertex).ToArray();
        _size = value;
      }
    }

    public Color Color { get; set; }

    private Vector3D[] vertices;

    public Cube(int x, int y, int z, double size, Color color) {
      _location = new(x, y, z);
      _size = size;
      Color = color;
      vertices = new Vector3D[] {
        new(x - _size / 2, y - _size / 2, z - _size / 2),
        new(x + _size / 2, y - _size / 2, z - _size / 2),
        new(x - _size / 2, y + _size / 2, z - _size / 2),
        new(x + _size / 2, y + _size / 2, z - _size / 2),
        new(x - _size / 2, y - _size / 2, z + _size / 2),
        new(x + _size / 2, y - _size / 2, z + _size / 2),
        new(x - _size / 2, y + _size / 2, z + _size / 2),
        new(x + _size / 2, y + _size / 2, z + _size / 2)
      };
    }

    public void Rotate(double phi) {
      vertices = vertices.Select(vertex => new Vector3D(
        vertex.X * Math.Cos(phi) - vertex.Z * Math.Sin(phi),
        vertex.Y,
        vertex.Z * Math.Cos(phi) + vertex.X * Math.Sin(phi)
      )).ToArray();
    }

    public void Render(ImageByteArray image, Func<Vector3D, Point> projection) {
      Point blu = projection(vertices[0]);
      Point bru = projection(vertices[1]);
      Point bld = projection(vertices[2]);
      Point brd = projection(vertices[3]);
      Point flu = projection(vertices[4]);
      Point fru = projection(vertices[5]);
      Point fld = projection(vertices[6]);
      Point frd = projection(vertices[7]);

      image.DrawLine(fld, frd, Color.Red);
      image.DrawLine(flu, fru, Color.Red);
      image.DrawLine(flu, fld, Color.Red);
      image.DrawLine(fru, frd, Color.Red);

      image.DrawLine(bld, brd, Color.Green);
      image.DrawLine(blu, bru, Color.Green);
      image.DrawLine(blu, bld, Color.Green);
      image.DrawLine(bru, brd, Color.Green);

      image.DrawLine(fld, bld, Color.Blue);
      image.DrawLine(flu, blu, Color.Blue);
      image.DrawLine(frd, brd, Color.Blue);
      image.DrawLine(fru, bru, Color.Blue);
    }
  }
}
