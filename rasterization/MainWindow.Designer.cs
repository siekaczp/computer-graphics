namespace rasterization {
  partial class MainWindow {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
      toolStrip1 = new ToolStrip();
      loadButton = new ToolStripButton();
      saveButton = new ToolStripButton();
      clearButton = new ToolStripButton();
      antialiasingButton = new ToolStripButton();
      toolStripSeparator1 = new ToolStripSeparator();
      lineButton = new ToolStripButton();
      circleButton = new ToolStripButton();
      polygonButton = new ToolStripButton();
      bezierButton = new ToolStripButton();
      toolStripSeparator2 = new ToolStripSeparator();
      deleteButton = new ToolStripButton();
      colorButton = new ToolStripButton();
      thicknessLabel = new ToolStripLabel();
      thicknessTextBox = new ToolStripTextBox();
      canvas = new PictureBox();
      rectangleButton = new ToolStripButton();
      toolStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize) canvas).BeginInit();
      SuspendLayout();
      // 
      // toolStrip1
      // 
      toolStrip1.Items.AddRange(new ToolStripItem[] { loadButton, saveButton, clearButton, antialiasingButton, toolStripSeparator1, lineButton, circleButton, rectangleButton, polygonButton, bezierButton, toolStripSeparator2, deleteButton, colorButton, thicknessLabel, thicknessTextBox });
      toolStrip1.Location = new Point(0, 0);
      toolStrip1.Name = "toolStrip1";
      toolStrip1.Size = new Size(800, 25);
      toolStrip1.TabIndex = 0;
      toolStrip1.Text = "toolStrip1";
      // 
      // loadButton
      // 
      loadButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
      loadButton.Image = (Image) resources.GetObject("loadButton.Image");
      loadButton.ImageTransparentColor = Color.Magenta;
      loadButton.Name = "loadButton";
      loadButton.Size = new Size(37, 22);
      loadButton.Text = "Load";
      loadButton.Click += LoadButton_Click;
      // 
      // saveButton
      // 
      saveButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
      saveButton.Image = (Image) resources.GetObject("saveButton.Image");
      saveButton.ImageTransparentColor = Color.Magenta;
      saveButton.Name = "saveButton";
      saveButton.Size = new Size(35, 22);
      saveButton.Text = "Save";
      saveButton.Click += SaveButton_Click;
      // 
      // clearButton
      // 
      clearButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
      clearButton.Image = (Image) resources.GetObject("clearButton.Image");
      clearButton.ImageTransparentColor = Color.Magenta;
      clearButton.Name = "clearButton";
      clearButton.Size = new Size(38, 22);
      clearButton.Text = "Clear";
      clearButton.Click += ClearButton_Click;
      // 
      // antialiasingButton
      // 
      antialiasingButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
      antialiasingButton.Image = (Image) resources.GetObject("antialiasingButton.Image");
      antialiasingButton.ImageTransparentColor = Color.Magenta;
      antialiasingButton.Name = "antialiasingButton";
      antialiasingButton.Size = new Size(120, 22);
      antialiasingButton.Text = "Turn on anti-aliasing";
      antialiasingButton.Click += AntialiasingButton_Click;
      // 
      // toolStripSeparator1
      // 
      toolStripSeparator1.Name = "toolStripSeparator1";
      toolStripSeparator1.Size = new Size(6, 25);
      // 
      // lineButton
      // 
      lineButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
      lineButton.Image = (Image) resources.GetObject("lineButton.Image");
      lineButton.ImageTransparentColor = Color.Magenta;
      lineButton.Name = "lineButton";
      lineButton.Size = new Size(33, 22);
      lineButton.Text = "Line";
      lineButton.Click += LineButton_Click;
      // 
      // circleButton
      // 
      circleButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
      circleButton.Image = (Image) resources.GetObject("circleButton.Image");
      circleButton.ImageTransparentColor = Color.Magenta;
      circleButton.Name = "circleButton";
      circleButton.Size = new Size(41, 22);
      circleButton.Text = "Circle";
      circleButton.Click += CircleButton_Click;
      // 
      // polygonButton
      // 
      polygonButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
      polygonButton.Image = (Image) resources.GetObject("polygonButton.Image");
      polygonButton.ImageTransparentColor = Color.Magenta;
      polygonButton.Name = "polygonButton";
      polygonButton.Size = new Size(55, 22);
      polygonButton.Text = "Polygon";
      polygonButton.Click += PolygonButton_Click;
      // 
      // bezierButton
      // 
      bezierButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
      bezierButton.Image = (Image) resources.GetObject("bezierButton.Image");
      bezierButton.ImageTransparentColor = Color.Magenta;
      bezierButton.Name = "bezierButton";
      bezierButton.Size = new Size(74, 22);
      bezierButton.Text = "Bezier curve";
      bezierButton.Click += BezierButton_Click;
      // 
      // toolStripSeparator2
      // 
      toolStripSeparator2.Name = "toolStripSeparator2";
      toolStripSeparator2.Size = new Size(6, 25);
      // 
      // deleteButton
      // 
      deleteButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
      deleteButton.Enabled = false;
      deleteButton.Image = (Image) resources.GetObject("deleteButton.Image");
      deleteButton.ImageTransparentColor = Color.Magenta;
      deleteButton.Name = "deleteButton";
      deleteButton.Size = new Size(44, 22);
      deleteButton.Text = "Delete";
      deleteButton.Click += DeleteButton_Click;
      // 
      // colorButton
      // 
      colorButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
      colorButton.Enabled = false;
      colorButton.Image = (Image) resources.GetObject("colorButton.Image");
      colorButton.ImageTransparentColor = Color.Magenta;
      colorButton.Name = "colorButton";
      colorButton.Size = new Size(40, 22);
      colorButton.Text = "Color";
      colorButton.Click += ColorButton_Click;
      // 
      // thicknessLabel
      // 
      thicknessLabel.Enabled = false;
      thicknessLabel.Name = "thicknessLabel";
      thicknessLabel.Size = new Size(61, 22);
      thicknessLabel.Text = "Thickness:";
      // 
      // thicknessTextBox
      // 
      thicknessTextBox.Enabled = false;
      thicknessTextBox.Name = "thicknessTextBox";
      thicknessTextBox.Size = new Size(100, 25);
      thicknessTextBox.Text = "1";
      thicknessTextBox.TextChanged += ThicknessTextBox_TextChanged;
      // 
      // canvas
      // 
      canvas.Dock = DockStyle.Fill;
      canvas.Location = new Point(0, 25);
      canvas.Name = "canvas";
      canvas.Size = new Size(800, 425);
      canvas.TabIndex = 1;
      canvas.TabStop = false;
      canvas.MouseClick += Canvas_MouseClick;
      // 
      // rectangleButton
      // 
      rectangleButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
      rectangleButton.Image = (Image) resources.GetObject("rectangleButton.Image");
      rectangleButton.ImageTransparentColor = Color.Magenta;
      rectangleButton.Name = "rectangleButton";
      rectangleButton.Size = new Size(63, 22);
      rectangleButton.Text = "Rectangle";
      rectangleButton.Click += RectangleButton_Click;
      // 
      // MainWindow
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(800, 450);
      Controls.Add(canvas);
      Controls.Add(toolStrip1);
      Name = "MainWindow";
      Text = "Vector graphics editor";
      FormClosed += MainWindow_FormClosed;
      toolStrip1.ResumeLayout(false);
      toolStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize) canvas).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private ToolStrip toolStrip1;
    private ToolStripButton loadButton;
    private ToolStripButton saveButton;
    private ToolStripButton clearButton;
    private ToolStripButton antialiasingButton;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton lineButton;
    private ToolStripButton circleButton;
    private ToolStripButton polygonButton;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripButton deleteButton;
    private ToolStripButton colorButton;
    private ToolStripLabel thicknessLabel;
    private PictureBox canvas;
    private ToolStripTextBox thicknessTextBox;
    private ToolStripButton bezierButton;
    private ToolStripButton rectangleButton;
  }
}