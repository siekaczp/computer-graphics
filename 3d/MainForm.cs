using Timer = System.Windows.Forms.Timer;

namespace _3d {
  public partial class MainForm : Form {
    private readonly Scene scene;
    private bool mousePressed = false;
    private Point mousePosition;
    private readonly Timer timer;

    public MainForm() {
      InitializeComponent();

      scene = new Scene(canvas);
      scene.Render();
      canvas.MouseWheel += Canvas_MouseWheel;
      canvas.MouseDown += Canvas_MouseDown;
      canvas.MouseUp += Canvas_MouseUp;
      canvas.MouseMove += Canvas_MouseMove;

      timer = new() {
        Interval = 20
      };
      timer.Tick += Timer_Tick;
    }

    private void Timer_Tick(object? sender, EventArgs e) {
      scene.Update();
      scene.Render();
    }

    private void Canvas_MouseUp(object? sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left)
        mousePressed = false;
    }

    private void Canvas_MouseDown(object? sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        mousePressed = true;
        mousePosition = e.Location;
      }
    }

    private void Canvas_MouseMove(object? sender, MouseEventArgs e) {
      if (!mousePressed)
        return;

      int dx = mousePosition.X - e.Location.X;
      int dy = mousePosition.Y - e.Location.Y;
      mousePosition = e.Location;

      if (dx == 0 && dy == 0)
        return;

      if (Math.Abs(dx) > Math.Abs(dy)) {
        double phi = (double) dx / 180;
        scene.Camera = Matrix4.RotateY(-phi) * scene.Camera;
      } else {
        double phi = (double) dy / 180;
        scene.Camera = Matrix4.RotateX(phi) * scene.Camera;
      }

      scene.Render();
    }

    private void Canvas_MouseWheel(object? sender, MouseEventArgs e) {
      scene.Camera.Z += e.Delta / 30;
      scene.Render();
    }

    private void SpinButton_Click(object sender, EventArgs e) {
      if (timer.Enabled)
        timer.Stop();
      else
        timer.Start();
    }
  }
}