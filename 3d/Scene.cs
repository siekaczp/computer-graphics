using System.Drawing.Imaging;
using System.Runtime.InteropServices;

using static System.Math;

namespace _3d {
  internal class Scene {
    public Vector3D Camera { get; set; } = new(0, 0, -250);

    public double ThetaX { get; set; } = 0;
    public double ThetaY { get; set; } = 0;
    public double ThetaZ { get; set; } = 0;

    private readonly int projectionPlaneDist;
    private readonly PictureBox pictureBox;
    private readonly Bitmap bitmap;
    private readonly Rectangle size;
    private readonly Graphics graphics;

    private readonly Cube cube = new(0, 0, 0, 100, Color.Red);

    public Scene(PictureBox box) {
      pictureBox = box;
      size = new(0, 0, pictureBox.Width, pictureBox.Height);
      bitmap = new(size.Width, size.Height, PixelFormat.Format24bppRgb);
      graphics = Graphics.FromImage(bitmap);
      pictureBox.Image = bitmap;
      projectionPlaneDist = (int) (0.4 * size.Width);
    }

    public void Update() {
      cube.Rotate(0.05);
    }

    public void Render() {
      graphics.Clear(Color.White);

      BitmapData imageData = bitmap.LockBits(size, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
      int stride = Math.Abs(imageData.Stride);
      byte[] imageBytes = new byte[stride * size.Height];
      IntPtr scan0 = imageData.Scan0;
      Marshal.Copy(scan0, imageBytes, 0, imageBytes.Length);
      ImageByteArray imageByteArray = new(imageBytes, size, stride);

      cube.Render(imageByteArray, Projection);

      Marshal.Copy(imageBytes, 0, scan0, imageBytes.Length);
      bitmap.UnlockBits(imageData);
      pictureBox.Refresh();
    }

    private Point Projection(Vector3D a) {
      Matrix3 Mx = new(new double[3, 3] { { 1, 0, 0 }, { 0, Cos(ThetaX), Sin(ThetaX) }, { 0, -Sin(ThetaX), Cos(ThetaX) } });
      Matrix3 My = new(new double[3, 3] { { Cos(ThetaY), 0, -Sin(ThetaY) }, { 0, 1, 0 }, { Sin(ThetaY), 0, Cos(ThetaY) } });
      Matrix3 Mz = new(new double[3, 3] { { Cos(ThetaZ), Sin(ThetaZ), 0 }, { -Sin(ThetaZ), Cos(ThetaZ), 0 }, { 0, 0, 1 } });

      Vector3D d = Mx * (My * (Mz * (a - Camera)));


      int x = (int) (projectionPlaneDist / d.Z * d.X) + size.Width / 2;
      int y = (int) (projectionPlaneDist / d.Z * d.Y) + size.Height / 2;

      return new(x, y);
    }
  }
}
