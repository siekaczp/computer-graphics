namespace _3d {
  internal interface ISolid {
    public Matrix4 LocalToGlobal { get; }
    public Triangle[] Triangles { get; }

    public AffineVector Ka { get; }
    public AffineVector Kd { get; }
    public AffineVector Ks { get; }
    public double M { get; }
  }
}
