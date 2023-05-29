namespace _3d {
  internal class Matrix4 {
    private readonly double[,] _matrix = new double[4, 4];

    private Matrix4() { }

    public Matrix4(double[,] matrix) => _matrix = matrix;

    public static Matrix4 operator *(Matrix4 A, Matrix4 B) {
      Matrix4 R = new();
      for (int i = 0; i < 4; i++) {
        for (int j = 0; j < 4; j++) {
          double sum = 0;
          for (int k = 0; k < 4; k++)
            sum += A._matrix[i, k] * B._matrix[k, j];
          R._matrix[i, j] = sum;
        }
      }
      return R;
    }

    public static AffineVector operator *(Matrix4 A, AffineVector v) => new(
      A._matrix[0, 0] * v.X + A._matrix[0, 1] * v.Y + A._matrix[0, 2] * v.Z + A._matrix[0, 3] * v.W,
      A._matrix[1, 0] * v.X + A._matrix[1, 1] * v.Y + A._matrix[1, 2] * v.Z + A._matrix[1, 3] * v.W,
      A._matrix[2, 0] * v.X + A._matrix[2, 1] * v.Y + A._matrix[2, 2] * v.Z + A._matrix[2, 3] * v.W,
      A._matrix[3, 0] * v.X + A._matrix[3, 1] * v.Y + A._matrix[3, 2] * v.Z + A._matrix[3, 3] * v.W
    );

    public static Matrix4 Translation(double x, double y, double z) {
      return new Matrix4(new double[4, 4] {
        { 1, 0, 0, x },
        { 0, 1, 0, y },
        { 0, 0, 1, z },
        { 0, 0, 0, 1 }
      });
    }

    public static Matrix4 RotateX(double theta) {
      double c = Math.Cos(theta);
      double s = Math.Sin(theta);
      return new Matrix4(new double[4, 4] {
        { 1, 0, 0, 0 },
        { 0, c, s, 0 },
        { 0, -s, c, 0 },
        { 0, 0, 0, 1 }
      });
    }

    public static Matrix4 RotateY(double theta) {
      double c = Math.Cos(theta);
      double s = Math.Sin(theta);
      return new Matrix4(new double[4, 4] {
        { c, 0, -s, 0 },
        { 0, 1, 0, 0 },
        { s, 0, c, 0 },
        { 0, 0, 0, 1 }
      });
    }

    public static Matrix4 RotateZ(double theta) {
      double c = Math.Cos(theta);
      double s = Math.Sin(theta);
      return new Matrix4(new double[4, 4] {
        { c, -s, 0, 0 },
        { s, c, 0, 0 },
        { 0, 0, 1, 0 },
        { 0, 0, 0, 1 }
      });
    }
  }
}
