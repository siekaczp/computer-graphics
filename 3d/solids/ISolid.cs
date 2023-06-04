namespace _3d {
  internal interface ISolid {
    public Matrix4 LocalToGlobal { get; }
    public Triangle[] Triangles { get; }
  }
}
