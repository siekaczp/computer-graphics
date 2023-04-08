using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace rasterization {
  public partial class MainWindow : Form {
    private bool _ShapeEditionControlsEnabled = false;
    public bool ShapeEditionControlsEnabled {
      get { return _ShapeEditionControlsEnabled; }
      set {
        _ShapeEditionControlsEnabled = value;
        deleteButton.Enabled = value;
        colorButton.Enabled = value;
        thicknessLabel.Enabled = value;
        thicknessTextBox.Enabled = value;
      }
    }

    enum State {
      Idle,
      FirstPointOfLine,
      SecondPointOfLine,
      FirstPointOfCircle,
      SecondPointOfCircle,
      NextPointOfPolygon,
    }

    private State state;
    private readonly Bitmap canvasBitmap;
    private readonly CompositeShape<Shape> shapes = new();
    private Point tempPoint;
    private readonly List<Point> tempListOfPoints = new();

    public MainWindow() {
      InitializeComponent();
      state = State.Idle;

      canvasBitmap = new Bitmap(canvas.Width, canvas.Height);
      canvas.Image = canvasBitmap;
      ResetImage();
    }

    private void ResetImage() {
      using Graphics g = Graphics.FromImage(canvasBitmap);
      g.Clear(Color.White);
      canvas.Refresh();
    }

    private void Render(Shape shape) {
      Rectangle rect = new(0, 0, canvasBitmap.Width, canvasBitmap.Height);
      BitmapData bmpData = canvasBitmap.LockBits(rect, ImageLockMode.ReadWrite, canvasBitmap.PixelFormat);

      IntPtr ptr = bmpData.Scan0;
      int bytes = Math.Abs(bmpData.Stride) * canvasBitmap.Height;
      byte[] rgbValues = new byte[bytes];
      Marshal.Copy(ptr, rgbValues, 0, bytes);

      shape.Draw(rgbValues, canvasBitmap.Width, canvasBitmap.Height, bmpData.Stride);
      Marshal.Copy(rgbValues, 0, ptr, bytes);

      canvasBitmap.UnlockBits(bmpData);
      canvas.Refresh();
    }

    private void Canvas_MouseClick(object sender, MouseEventArgs e) {
      switch (state) {
      case State.FirstPointOfLine:
        state = State.SecondPointOfLine;
        tempPoint = e.Location;
        break;

      case State.SecondPointOfLine:
        state = State.Idle;
        Line newLine = new(tempPoint, e.Location);
        shapes.Add(newLine);
        Render(newLine);
        lineButton.Checked = false;
        break;

      case State.FirstPointOfCircle:
        tempPoint = e.Location;
        state = State.SecondPointOfCircle;
        break;

      case State.SecondPointOfCircle:
        state = State.Idle;
        int r = (int) Math.Sqrt((tempPoint.X - e.Location.X) * (tempPoint.X - e.Location.X)
          + (tempPoint.Y - e.Location.Y) * (tempPoint.Y - e.Location.Y));
        Circle newCircle = new(tempPoint, r);
        shapes.Add(newCircle);
        Render(newCircle);
        circleButton.Checked = false;
        break;

      case State.NextPointOfPolygon:
        if (tempListOfPoints.Count >= 3) {
          Point firstPoint = tempListOfPoints[0];
          int dist = (firstPoint.X - e.Location.X) * (firstPoint.X - e.Location.X)
          + (firstPoint.Y - e.Location.Y) * (firstPoint.Y - e.Location.Y);

          if (dist <= 100) {
            state = State.Idle;
            Polygon newPolygon = new(new List<Point>(tempListOfPoints));
            shapes.Add(newPolygon);
            Render(newPolygon);
            polygonButton.Checked = false;
            break;
          }
        }

        tempListOfPoints.Add(e.Location);
        break;
      }
    }

    private void LoadButton_Click(object sender, EventArgs e) {
      throw new NotImplementedException();
    }

    private void SaveButton_Click(object sender, EventArgs e) {
      throw new NotImplementedException();
    }

    private void ClearButton_Click(object sender, EventArgs e) {
      shapes.Clear();
      ResetImage();
    }

    private void AntialiasingButton_Click(object sender, EventArgs e) {
      throw new NotImplementedException();
    }

    private void LineButton_Click(object sender, EventArgs e) {
      switch (state) {
      case State.Idle:
        state = State.FirstPointOfLine;
        lineButton.Checked = true;
        break;

      case State.FirstPointOfLine:
        state = State.Idle;
        tempPoint = new Point();
        lineButton.Checked = false;
        break;
      }
    }

    private void CircleButton_Click(object sender, EventArgs e) {
      switch (state) {
      case State.Idle:
        state = State.FirstPointOfCircle;
        circleButton.Checked = true;
        break;

      case State.FirstPointOfCircle:
        state = State.Idle;
        tempPoint = new Point();
        circleButton.Checked = false;
        break;
      }
    }

    private void PolygonButton_Click(object sender, EventArgs e) {
      switch (state) {
      case State.Idle:
        state = State.NextPointOfPolygon;
        polygonButton.Checked = true;
        break;

      case State.NextPointOfPolygon:
        state = State.Idle;
        polygonButton.Checked = false;
        break;
      }

      tempListOfPoints.Clear();
    }

    private void DeleteButton_Click(object sender, EventArgs e) {
      throw new NotImplementedException();
    }

    private void ColorButton_Click(object sender, EventArgs e) {
      ColorDialog colorDialog = new() {
        Color = ForeColor // TODO: get color of selected shape
      };

      if (colorDialog.ShowDialog() == DialogResult.OK) {
        MessageBox.Show(colorDialog.Color.ToString());
        // TODO: assign color
        throw new NotImplementedException();
      }
    }

    private void ThicknessTextBox_TextChanged(object sender, EventArgs e) {
      if (!int.TryParse(thicknessTextBox.Text, out int thickness)) {
        thickness = 1;
      }
      // TODO: assign thickness
      throw new NotImplementedException();
    }
  }
}