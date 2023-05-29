namespace _3d {
  internal class Cube {
    private double t = 0;

    public Color Color { get; set; }

    private AffineVector[] vertices;

    public Cube(int x, int y, int z, double size, Color color) {
      Color = color;
      vertices = new AffineVector[] {
        new(x - size / 2, y - size / 2, z - size / 2),
        new(x + size / 2, y - size / 2, z - size / 2),
        new(x - size / 2, y + size / 2, z - size / 2),
        new(x + size / 2, y + size / 2, z - size / 2),
        new(x - size / 2, y - size / 2, z + size / 2),
        new(x + size / 2, y - size / 2, z + size / 2),
        new(x - size / 2, y + size / 2, z + size / 2),
        new(x + size / 2, y + size / 2, z + size / 2)
      };
    }

    public void Update(double dt) {
      vertices = vertices.Select(vertex => Matrix4.Translation(0, -3 * Math.Cos(t), 0) * (Matrix4.RotateY(dt) * vertex)).ToArray();
      t += dt;
    }

    public void Render(ImageByteArray image, Func<AffineVector, Point> projection) {
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
