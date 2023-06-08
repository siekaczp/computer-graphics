using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace _3d {
  internal class Scene {
    private readonly PictureBox pictureBox;
    private readonly Bitmap bitmap;
    private readonly Rectangle size;
    private readonly Graphics graphics;

    private readonly AffineVector OrientationUp = new(0, 1, 0, 0);
    private readonly Matrix4 ProjectionMatrix;
    private Matrix4 CameraMatrix = null!;

    private AffineVector camera = new(0, 0, -250);
    public AffineVector Camera {
      get => camera; set {
        camera = value;
        UpdateCameraMatrix();
      }
    }

    private AffineVector cameraTarget = new(0, 0, 0);
    public AffineVector CameraTarget {
      get => cameraTarget; set {
        cameraTarget = value;
        UpdateCameraMatrix();
      }
    }

    private readonly AffineVector lightSource = new(250, -150, 200);

    private readonly AffineVector lightIntensity = new(1, 1, 1, 0);

    private readonly List<ISolid> solids = new();

    public Scene(PictureBox box) {
      pictureBox = box;
      size = new(0, 0, pictureBox.Width, pictureBox.Height);
      bitmap = new(size.Width, size.Height, PixelFormat.Format24bppRgb);
      graphics = Graphics.FromImage(bitmap);
      pictureBox.Image = bitmap;

      ProjectionMatrix = new(new double[4, 4] {
        { -size.Width * 0.4, 0, size.Width / 2, 0 },
        { 0, size.Width * 0.4, size.Height / 2, 0 },
        { 0, 0, 0, 1 },
        { 0, 0, 1, 0 }
      });

      UpdateCameraMatrix();

      //solids.Add(new Sphere(0, 0, 0, 100));
      solids.Add(new Cylinder(0, -100, 0, 200, 100));
    }

    public void UpdateCameraMatrix() {
      AffineVector Z = Camera - CameraTarget;
      Z.Length = 1;
      AffineVector X = AffineVector.CrossProduct(OrientationUp, Z);
      X.Length = 1;
      AffineVector Y = AffineVector.CrossProduct(Z, X);
      Y.Length = 1;

      CameraMatrix = new(new double[4, 4] {
        { X.X, X.Y, X.Z, AffineVector.DotProduct(X, Camera) },
        { Y.X, Y.Y, Y.Z, AffineVector.DotProduct(Y, Camera) },
        { Z.X, Z.Y, Z.Z, AffineVector.DotProduct(Z, Camera) },
        { 0, 0, 0, 1 }
      });
    }

    public void Update() {
      // cube.Update(0.05);
    }

    public void Render() {
      graphics.Clear(Color.White);

      BitmapData imageData = bitmap.LockBits(size, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
      int stride = Math.Abs(imageData.Stride);
      byte[] imageBytes = new byte[stride * size.Height];
      IntPtr scan0 = imageData.Scan0;
      Marshal.Copy(scan0, imageBytes, 0, imageBytes.Length);
      ImageByteArray imageByteArray = new(imageBytes, size, stride);

      foreach (var solid in solids) {
        foreach (var triangle in solid.Triangles) {
          Point p1 = Projection(triangle.V1.p, solid.LocalToGlobal);
          Point p2 = Projection(triangle.V2.p, solid.LocalToGlobal);
          Point p3 = Projection(triangle.V3.p, solid.LocalToGlobal);

          if ((p2.X - p1.X) * (p3.Y - p1.Y) - (p2.Y - p1.Y) * (p3.X - p1.X) > 0) {
            var p = (double) 1 / 3 * (triangle.V1.p + triangle.V2.p + triangle.V3.p);
            var n = triangle.V1.n + triangle.V2.n + triangle.V3.n;
            n.Length = 1;

            Color color = PhongIlumination(solid, p, n);
            imageByteArray.DrawTriangle(new Point[] { p1, p2, p3 }, color);
          }
        }
      }

      Marshal.Copy(imageBytes, 0, scan0, imageBytes.Length);
      bitmap.UnlockBits(imageData);
      pictureBox.Refresh();
    }

    private Point Projection(AffineVector c, Matrix4 ToLocal) {
      AffineVector d = ProjectionMatrix * (CameraMatrix * (ToLocal * c));
      return new((int) (d.X / d.W), (int) (d.Y / d.W));
    }

    private Color PhongIlumination(ISolid solid, AffineVector p, AffineVector n) {
      var l = lightSource - p;
      l.Length = 1;

      var v = p - camera;
      v.Length = 1;
      var r = 2 * AffineVector.DotProduct(n, l) * n - l;

      AffineVector colorVector = 255 * (solid.Ka + (
        Math.Max(AffineVector.DotProduct(n, l), 0) * solid.Kd + Math.Pow(Math.Max(AffineVector.DotProduct(v, r), 0), solid.M) * solid.Ks
      ) * lightIntensity);
      return Color.FromArgb(
        colorVector.X > 255 ? 255 : (int) colorVector.X,
        colorVector.Y > 255 ? 255 : (int) colorVector.Y,
        colorVector.Z > 255 ? 255 : (int) colorVector.Z
      );
    }
  }
}
