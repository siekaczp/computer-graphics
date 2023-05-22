namespace _3d {
  internal class Matrix3 {
    private double[,] _matrix = new double[3, 3];

    public Matrix3() { }

    public Matrix3(double[,] matrix) {
      _matrix = matrix;
    }

    public void SetAt(int i, int j, double value) => _matrix[i - 1, j - 1] = value;

    public double At(int i, int j) => _matrix[i - 1, j - 1];
  }

  internal class Vector3D {
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public double Length {
      get => Math.Sqrt(X * X + Y * Y + Z * Z);
      set {
        X *= value / Length;
        Y *= value / Length;
        Z *= value / Length;
      }
    }

    public Vector3D(double x, double y, double z) {
      X = x;
      Y = y;
      Z = z;
    }

    public static Vector3D operator +(Vector3D a, Vector3D b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    public static Vector3D operator *(double c, Vector3D a) => new(c * a.X, c * a.Y, c * a.Z);

    public static Vector3D operator +(Vector3D a) => a;
    public static Vector3D operator -(Vector3D a) => -1 * a;
    public static Vector3D operator -(Vector3D a, Vector3D b) => a + (-b);

    public static double operator *(Vector3D a, Vector3D b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;

    public static Vector3D operator *(Matrix3 A, Vector3D v) => new(
      A.At(1, 1) * v.X + A.At(1, 2) * v.Y + A.At(1, 3) * v.Z,
      A.At(2, 1) * v.X + A.At(2, 2) * v.Y + A.At(2, 3) * v.Z,
      A.At(3, 1) * v.X + A.At(3, 2) * v.Y + A.At(3, 3) * v.Z
    );

    public override string ToString() => $"({X}, {Y}, {Z})";
  }
}
