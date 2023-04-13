using System.Drawing.Imaging;
using System.Reflection.Metadata;
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

    private enum State {
      Idle,
      FirstPointOfLine,
      SecondPointOfLine,
      FirstPointOfCircle,
      SecondPointOfCircle,
      NextPointOfPolygon,
      ShapeSelected,
    }

    private State state;
    private readonly Bitmap canvasBitmap;

    private readonly CompositeShape<Shape> shapes = new();
    private Shape? selectedShape = null;

    private Point tempPoint;
    private readonly List<Point> tempListOfPoints = new();

    private bool Antialiasing = false;

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

      shape.Draw(new ImageByteArray() {
        RgbValues = rgbValues, Width = canvasBitmap.Width, Height = canvasBitmap.Height, Stride = bmpData.Stride
      }, Antialiasing);

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

          if (dist <= 4 * Shape.Epsilon * Shape.Epsilon) {
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

      case State.Idle:
        selectedShape = shapes.CheckColision(e.Location);
        if (selectedShape != null) {
          state = State.ShapeSelected;
          ShapeEditionControlsEnabled = true;
          thicknessTextBox.Text = selectedShape.Thickness.ToString();
          selectedShape.Color = Color.Red;
          Render(selectedShape);
        }
        break;

      case State.ShapeSelected:
        selectedShape = null;
        ShapeEditionControlsEnabled = false;
        state = State.Idle;
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
      if (Antialiasing) {
        Antialiasing = false;
        antialiasingButton.Text = "Turn on anti-aliasing";
      } else {
        Antialiasing = true;
        antialiasingButton.Text = "Turn off anti-aliasing";
      }

      ResetImage();
      Render(shapes);
    }

    private void UncheckAllButtons() {
      lineButton.Checked = false;
      circleButton.Checked = false;
      polygonButton.Checked = false;
      ShapeEditionControlsEnabled = false;
    }

    private void LineButton_Click(object sender, EventArgs e) {
      UncheckAllButtons();

      if (state == State.FirstPointOfLine || state == State.SecondPointOfLine) {
        state = State.Idle;
        tempPoint = new Point();
        return;
      }

      state = State.FirstPointOfLine;
      lineButton.Checked = true;
    }

    private void CircleButton_Click(object sender, EventArgs e) {
      UncheckAllButtons();

      if (state == State.FirstPointOfCircle || state == State.SecondPointOfCircle) {
        state = State.Idle;
        tempPoint = new Point();
        return;
      }

      state = State.FirstPointOfCircle;
      circleButton.Checked = true;
    }

    private void PolygonButton_Click(object sender, EventArgs e) {
      UncheckAllButtons();
      tempListOfPoints.Clear();

      if (state == State.NextPointOfPolygon) {
        state = State.Idle;
        tempPoint = new Point();
        return;
      }

      state = State.NextPointOfPolygon;
      polygonButton.Checked = true;
    }

    private void DeleteButton_Click(object sender, EventArgs e) {
      if (selectedShape == null)
        return;

      shapes.Remove(selectedShape);
      selectedShape = null;
      UncheckAllButtons();
      state = State.Idle;

      ResetImage();
      Render(shapes);
    }

    private void ColorButton_Click(object sender, EventArgs e) {
      ColorDialog colorDialog = new() {
        Color = selectedShape?.Color ?? Color.Black,
        FullOpen = true,
      };

      if (colorDialog.ShowDialog() == DialogResult.OK) {
        if (selectedShape == null)
          return;

        selectedShape.Color = colorDialog.Color;
        Render(selectedShape);
      }
    }

    private void ThicknessTextBox_TextChanged(object sender, EventArgs e) {
      if (!int.TryParse(thicknessTextBox.Text, out int thickness)) {
        thickness = 1;
      }

      if (selectedShape == null)
        return;

      int oldThickness = selectedShape.Thickness;

      selectedShape.Thickness = thickness;

      if (oldThickness > thickness) {
        ResetImage();
        Render(shapes);
      } else {
        Render(selectedShape);
      }
    }
  }
}