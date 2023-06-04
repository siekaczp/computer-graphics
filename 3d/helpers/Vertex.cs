namespace _3d {
  internal class Vertex {
    public readonly AffineVector p;
    public readonly AffineVector n;

    public Vertex(double px, double py, double pz, double nx, double ny, double nz) {
      p = new AffineVector(px, py, pz, 1);
      n = new AffineVector(nx, ny, nz, 0);
    }
  }
}
