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
      ShapeMoving,
      ShapeEditing,
    }

    private readonly Image moveIcon = Image.FromFile("move_icon.png");
    private const int moveIconSize = 11;

    private readonly Bitmap canvasBitmap;
    private readonly Graphics canvasGraphics;
    private readonly PictureBox tempLayer;
    private readonly Bitmap tempLayerBitmap;
    private readonly Graphics tempLayerGraphics;

    private State state;
    private readonly CompositeShape<Shape> shapes = new();
    private Shape? newShape = null;
    private Shape? selectedShape = null;

    private readonly List<Point> tempListOfPoints = new();
    private Point lastPosition;

    private bool Antialiasing = false;

    public MainWindow() {
      InitializeComponent();
      state = State.Idle;

      canvasBitmap = new Bitmap(canvas.Width, canvas.Height);
      canvas.Image = canvasBitmap;
      canvasGraphics = Graphics.FromImage(canvasBitmap);
      canvasGraphics.Clear(Color.White);
      canvas.Refresh();

      tempLayer = new() {
        Parent = canvas,
        Size = new Size(canvas.Width, canvas.Height),
        BackColor = Color.Transparent
      };

      tempLayerBitmap = new Bitmap(tempLayer.Width, tempLayer.Height);
      tempLayer.Image = tempLayerBitmap;
      tempLayerGraphics = Graphics.FromImage(tempLayerBitmap);
      tempLayerGraphics.Clear(Color.Transparent);
      tempLayer.Refresh();

      tempLayer.MouseClick += Canvas_MouseClick;
      tempLayer.MouseDown += Canvas_MouseDown;
      tempLayer.MouseUp += Canvas_MouseUp;
      tempLayer.MouseMove += Canvas_MouseMove;
    }

    private void Render(Bitmap bitmap, Shape shape) {
      Rectangle rect = new(0, 0, bitmap.Width, bitmap.Height);
      BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

      IntPtr ptr = bmpData.Scan0;
      int bytes = Math.Abs(bmpData.Stride) * bitmap.Height;
      byte[] rgbValues = new byte[bytes];
      Marshal.Copy(ptr, rgbValues, 0, bytes);

      shape.Draw(new ImageByteArray() {
        RgbValues = rgbValues, Width = bitmap.Width, Height = bitmap.Height, Stride = bmpData.Stride
      }, Antialiasing);

      Marshal.Copy(rgbValues, 0, ptr, bytes);
      bitmap.UnlockBits(bmpData);
    }

    private void Canvas_MouseClick(object? sender, MouseEventArgs e) {
      switch (state) {
      case State.FirstPointOfLine:
        state = State.SecondPointOfLine;
        newShape = new Line(e.Location, e.Location);
        Render(tempLayerBitmap, newShape);
        tempLayer.Refresh();
        break;

      case State.SecondPointOfLine:
        state = State.Idle;
        if (newShape is null)
          break;

        (newShape as Line)!.EndPoint = e.Location;
        Render(canvasBitmap, newShape);
        canvas.Refresh();

        tempLayerGraphics.Clear(Color.Transparent);
        tempLayer.Refresh();

        shapes.Add(newShape);
        newShape = null;

        lineButton.Checked = false;
        break;

      case State.FirstPointOfCircle:
        state = State.SecondPointOfCircle;
        newShape = new Circle(e.Location, e.Location);
        Render(tempLayerBitmap, newShape);
        tempLayer.Refresh();
        break;

      case State.SecondPointOfCircle:
        state = State.Idle;
        if (newShape is null)
          break;

        newShape = new Circle((newShape as Circle)!.Center, e.Location);
        Render(canvasBitmap, newShape);
        canvas.Refresh();

        tempLayerGraphics.Clear(Color.Transparent);
        tempLayer.Refresh();

        shapes.Add(newShape);
        newShape = null;

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

            Render(canvasBitmap, newPolygon);
            canvas.Refresh();

            tempLayerGraphics.Clear(Color.Transparent);
            tempLayer.Refresh();

            polygonButton.Checked = false;
            break;
          }
        }

        tempListOfPoints.Add(e.Location);
        break;

      case State.Idle:
        selectedShape = shapes.CheckColision(e.Location);
        if (selectedShape is null)
          break;

        state = State.ShapeSelected;
        ShapeEditionControlsEnabled = true;
        thicknessTextBox.Text = selectedShape.Thickness.ToString();

        tempLayerGraphics.Clear(Color.Transparent);
        Point center = selectedShape!.GetCenter();
        tempLayerGraphics.DrawImage(moveIcon, center.X - moveIconSize, center.Y - moveIconSize);
        tempLayer.Refresh();
        break;

      case State.ShapeSelected:
        state = State.Idle;
        selectedShape = null;
        ShapeEditionControlsEnabled = false;
        tempLayerGraphics.Clear(Color.Transparent);
        tempLayer.Refresh();
        break;
      }
    }

    private void Canvas_MouseDown(object? sender, MouseEventArgs e) {
      if (state != State.ShapeSelected || selectedShape == null)
        return;

      int selectedX = selectedShape.GetCenter().X;
      int selectedY = selectedShape.GetCenter().Y;
      lastPosition = e.Location;

      if (e.Location.X >= selectedX - moveIconSize && e.Location.X <= selectedX + moveIconSize
       && e.Location.Y >= selectedY - moveIconSize && e.Location.Y <= selectedY + moveIconSize) {
        state = State.ShapeMoving;
      } else {
        state = State.ShapeEditing;
      }
    }

    private void Canvas_MouseUp(object? sender, MouseEventArgs e) {
      if ((state != State.ShapeMoving && state != State.ShapeEditing) || selectedShape == null)
        return;

      tempLayerGraphics.Clear(Color.Transparent);
      tempLayer.Refresh();

      canvasGraphics.Clear(Color.White);
      Render(canvasBitmap, shapes);
      canvas.Refresh();

      state = State.Idle;
      selectedShape = null;
      ShapeEditionControlsEnabled = false;
    }

    private void Canvas_MouseMove(object? sender, MouseEventArgs e) {
      switch (state) {
      case State.SecondPointOfLine:
        if (newShape is null)
          break;

        (newShape as Line)!.EndPoint = e.Location;
        tempLayerGraphics.Clear(Color.Transparent);
        Render(tempLayerBitmap, newShape);
        tempLayer.Refresh();
        break;

      case State.SecondPointOfCircle:
        if (newShape is null)
          break;

        newShape = new Circle((newShape as Circle)!.Center, e.Location);
        tempLayerGraphics.Clear(Color.Transparent);
        Render(tempLayerBitmap, newShape);
        tempLayer.Refresh();
        break;

      case State.NextPointOfPolygon:
        if (tempListOfPoints.Count == 0)
          break;

        tempLayerGraphics.Clear(Color.Transparent);
        for (int i = 1; i < tempListOfPoints.Count; i++)
          Render(tempLayerBitmap, new Line(tempListOfPoints[i - 1], tempListOfPoints[i]));
        Render(tempLayerBitmap, new Line(tempListOfPoints.Last(), e.Location));
        tempLayer.Refresh();
        break;

      case State.ShapeMoving:
      case State.ShapeEditing:
        int dx = e.Location.X - lastPosition.X;
        int dy = e.Location.Y - lastPosition.Y;

        if (state == State.ShapeMoving) {
          selectedShape!.Move(dx, dy);
        } else {
          if (!selectedShape!.Edit(lastPosition, dx, dy))
            state = State.ShapeSelected;
        }

        lastPosition = e.Location;

        tempLayerGraphics.Clear(Color.Transparent);
        Render(tempLayerBitmap, selectedShape);
        Point center = selectedShape.GetCenter();
        tempLayerGraphics.DrawImage(moveIcon, center.X - moveIconSize, center.Y - moveIconSize);
        tempLayer.Refresh();
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
      ShapeEditionControlsEnabled = false;
      shapes.Clear();
      canvasGraphics.Clear(Color.White);
      canvas.Refresh();
      tempLayerGraphics.Clear(Color.Transparent);
      tempLayer.Refresh();
    }

    private void AntialiasingButton_Click(object sender, EventArgs e) {
      if (Antialiasing) {
        Antialiasing = false;
        antialiasingButton.Text = "Turn on anti-aliasing";
      } else {
        Antialiasing = true;
        antialiasingButton.Text = "Turn off anti-aliasing";
      }

      canvasGraphics.Clear(Color.White);
      Render(canvasBitmap, shapes);
      canvas.Refresh();
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
        return;
      }

      state = State.FirstPointOfLine;
      tempLayerGraphics.Clear(Color.Transparent);
      tempLayer.Refresh();
      lineButton.Checked = true;
    }

    private void CircleButton_Click(object sender, EventArgs e) {
      UncheckAllButtons();

      if (state == State.FirstPointOfCircle || state == State.SecondPointOfCircle) {
        state = State.Idle;
        return;
      }

      state = State.FirstPointOfCircle;
      tempLayerGraphics.Clear(Color.Transparent);
      tempLayer.Refresh();
      circleButton.Checked = true;
    }

    private void PolygonButton_Click(object sender, EventArgs e) {
      UncheckAllButtons();
      tempListOfPoints.Clear();

      if (state == State.NextPointOfPolygon) {
        state = State.Idle;
        return;
      }

      state = State.NextPointOfPolygon;
      tempLayerGraphics.Clear(Color.Transparent);
      tempLayer.Refresh();
      polygonButton.Checked = true;
    }

    private void DeleteButton_Click(object sender, EventArgs e) {
      if (selectedShape == null)
        return;

      shapes.Remove(selectedShape);
      selectedShape = null;
      UncheckAllButtons();
      state = State.Idle;

      canvasGraphics.Clear(Color.White);
      Render(canvasBitmap, shapes);
      canvas.Refresh();
      tempLayerGraphics.Clear(Color.Transparent);
      tempLayer.Refresh();
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
        Render(canvasBitmap, selectedShape);
        canvas.Refresh();
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
        canvasGraphics.Clear(Color.White);
        Render(canvasBitmap, shapes);
      } else {
        Render(canvasBitmap, selectedShape);
      }
      canvas.Refresh();
    }

    private void MainWindow_FormClosed(object sender, FormClosedEventArgs e) {
      canvasGraphics.Dispose();
      tempLayerGraphics.Dispose();
    }
  }
}