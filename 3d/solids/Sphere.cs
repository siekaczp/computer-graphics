namespace _3d {
  internal class Sphere : ISolid {
    private const int m = 20;
    private const int n = 30;

    private readonly Vertex[] vertices = new Vertex[m * n + 2];

    public Matrix4 LocalToGlobal { get; }
    public Triangle[] Triangles { get; } = new Triangle[2 * m * n];

    public AffineVector Ka => new(0.05, 0.05, 0.15, 0);
    public AffineVector Kd => new(0.2, 0.2, 0.8, 0);
    public AffineVector Ks => new(0.4, 0.4, 0.4, 0);
    public double M => 10;

    public Sphere(double x, double y, double z, double r) {
      LocalToGlobal = Matrix4.Translation(x, y, z);

      vertices[0] = new Vertex(0, r, 0, 0, 1, 0);
      vertices[m * n + 1] = new Vertex(0, -r, 0, 0, -1, 0);

      for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
          double px = r * Math.Cos(2 * Math.PI / m * j) * Math.Sin(Math.PI / (n + 1) * (i + 1));
          double py = r * Math.Cos(Math.PI / (n + 1) * (i + 1));
          double pz = r * Math.Sin(2 * Math.PI / m * j) * Math.Sin(Math.PI / (n + 1) * (i + 1));
          vertices[i * m + j + 1] = new Vertex(px, py, pz, px / r, py / r, pz / r);
        }
      }

      var T = (int a, int b, int c) => new Triangle(vertices[a], vertices[b], vertices[c]);

      for (int i = 0; i <= m - 2; i++)
        Triangles[i] = T(0, i + 2, i + 1);
      Triangles[m - 1] = T(0, 1, m);

      for (int i = 0; i <= m - 2; i++)
        Triangles[(2 * n - 1) * m + i] = T(n * m + 1, (n - 1) * m + i + 1, (n - 1) * m + i + 2);
      Triangles[2 * n * m - 1] = T(n * m + 1, n * m, (n - 1) * m + 1);

      for (int i = 0; i <= n - 2; i++) {
        for (int j = 1; j <= m - 1; j++)
          Triangles[(2 * i + 1) * m + j - 1] = T(i * m + j, i * m + j + 1, (i + 1) * m + j + 1);
        Triangles[(2 * i + 2) * m - 1] = T((i + 1) * m, i * m + 1, (i + 1) * m + 1);

        for (int j = 1; j <= m - 1; j++)
          Triangles[(2 * i + 2) * m + j - 1] = T(i * m + j, (i + 1) * m + j + 1, (i + 1) * m + j);
        Triangles[(2 * i + 3) * m - 1] = T((i + 1) * m, (i + 1) * m + 1, (i + 2) * m);
      }
    }
  }
}
