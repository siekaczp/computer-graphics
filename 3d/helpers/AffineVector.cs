namespace _3d {
  internal class AffineVector {
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public double W { get; set; }

    public double Length {
      get => Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
      set {
        double l = value / Length;
        X *= l;
        Y *= l;
        Z *= l;
        W *= l;
      }
    }

    public AffineVector(double x, double y, double z, double w = 1) {
      X = x;
      Y = y;
      Z = z;
      W = w;
    }

    public static AffineVector operator +(AffineVector a, AffineVector b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
    public static AffineVector operator *(double c, AffineVector a) => new(c * a.X, c * a.Y, c * a.Z, c * a.W);

    public static AffineVector operator +(AffineVector a) => a;
    public static AffineVector operator -(AffineVector a) => -1 * a;
    public static AffineVector operator -(AffineVector a, AffineVector b) => a + (-b);

    public static AffineVector CrossProduct(AffineVector a, AffineVector b) => new(
      a.Y * b.Z - a.Z * b.Y,
      a.Z * b.X - a.X * b.Z,
      a.X * b.Y - a.Y * b.X,
      0
    );

    public static double DotProduct(AffineVector a, AffineVector b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;
  }
}
