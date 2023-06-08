namespace _3d {
  internal class Cylinder : ISolid {
    private const int n = 20;

    private readonly Vertex[] vertices = new Vertex[4 * n + 2];

    public Matrix4 LocalToGlobal { get; }
    public Triangle[] Triangles { get; } = new Triangle[4 * n];

    public AffineVector Ka => new(0.05, 0.05, 0.15, 0);
    public AffineVector Kd => new(0.2, 0.2, 0.8, 0);
    public AffineVector Ks => new(0.4, 0.4, 0.4, 0);
    public double M => 10;

    public Cylinder(double x, double y, double z, double h, double r) {
      LocalToGlobal = Matrix4.Translation(x, y, z);
      var T = (int a, int b, int c) => new Triangle(vertices[a], vertices[b], vertices[c]);

      vertices[0] = new Vertex(0, h, 0, 0, 1, 0);
      for (int i = 0; i <= n - 1; i++)
        vertices[i + 1] = new Vertex(r * Math.Cos(2 * Math.PI / n * i), h, r * Math.Sin(2 * Math.PI / n * i), 0, 1, 0);

      for (int i = 0; i <= n - 2; i++)
        Triangles[i] = T(0, i + 2, i + 1);
      Triangles[n - 1] = T(0, 1, n);


      vertices[4 * n + 1] = new Vertex(0, 0, 0, 0, -1, 0);
      for (int i = 0; i <= n - 1; i++)
        vertices[3 * n + i + 1] = new Vertex(r * Math.Cos(2 * Math.PI / n * i), 0, r * Math.Sin(2 * Math.PI / n * i), 0, -1, 0);

      for (int i = 3 * n; i <= 4 * n - 2; i++)
        Triangles[i] = T(4 * n + 1, i + 1, i + 2);
      Triangles[4 * n - 1] = T(4 * n + 1, 4 * n, 3 * n + 1);

      for (int i = n + 1; i <= 2 * n; i++)
        vertices[i] = new Vertex(vertices[i - n].p.X, vertices[i - n].p.Y, vertices[i - n].p.Z, vertices[i - n].p.X / r, 0, vertices[i - n].p.Z / r);
      for (int i = 2 * n + 1; i <= 3 * n; i++)
        vertices[i] = new Vertex(vertices[i + n].p.X, vertices[i + n].p.Y, vertices[i + n].p.Z, vertices[i + n].p.X / r, 0, vertices[i + n].p.Z / r);

      for (int i = n; i <= 2 * n - 2; i++)
        Triangles[i] = T(i + 1, i + 2, i + 1 + n);
      Triangles[2 * n - 1] = T(2 * n, n + 1, 3 * n);
      for (int i = 2 * n; i <= 3 * n - 2; i++)
        Triangles[i] = T(i + 1, i + 2 - n, i + 2);
      Triangles[3 * n - 1] = T(3 * n, n + 1, 2 * n + 1);
    }
  }
}
