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
      antialiasingButton = new ToolStripButton();
      drawDropdownButton = new ToolStripDropDownButton();
      lineButton = new ToolStripMenuItem();
      circleButton = new ToolStripMenuItem();
      rectangleButton = new ToolStripMenuItem();
      polygonButton = new ToolStripMenuItem();
      bezierButton = new ToolStripMenuItem();
      toolStripSeparator2 = new ToolStripSeparator();
      deleteButton = new ToolStripButton();
      edgeColorButton = new ToolStripButton();
      fillColorButton = new ToolStripButton();
      fillImageButton = new ToolStripButton();
      clearFillButton = new ToolStripButton();
      thicknessLabel = new ToolStripLabel();
      thicknessTextBox = new ToolStripTextBox();
      canvas = new PictureBox();
      fileDropdownButton = new ToolStripDropDownButton();
      loadButton = new ToolStripMenuItem();
      saveButton = new ToolStripMenuItem();
      clearButton = new ToolStripMenuItem();
      clipButton = new ToolStripButton();
      toolStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize) canvas).BeginInit();
      SuspendLayout();
      // 
      // toolStrip1
      // 
      toolStrip1.Items.AddRange(new ToolStripItem[] { fileDropdownButton, drawDropdownButton, antialiasingButton, toolStripSeparator2, deleteButton, edgeColorButton, fillColorButton, fillImageButton, clearFillButton, thicknessLabel, thicknessTextBox, clipButton });
      toolStrip1.Location = new Point(0, 0);
      toolStrip1.Name = "toolStrip1";
      toolStrip1.Size = new Size(800, 25);
      toolStrip1.TabIndex = 0;
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
      // drawDropdownButton
      // 
      drawDropdownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
      drawDropdownButton.DropDownItems.AddRange(new ToolStripItem[] { lineButton, circleButton, rectangleButton, polygonButton, bezierButton });
      drawDropdownButton.Image = (Image) resources.GetObject("drawDropdownButton.Image");
      drawDropdownButton.ImageTransparentColor = Color.Magenta;
      drawDropdownButton.Name = "drawDropdownButton";
      drawDropdownButton.Size = new Size(47, 22);
      drawDropdownButton.Text = "Draw";
      // 
      // lineButton
      // 
      lineButton.Name = "lineButton";
      lineButton.Size = new Size(137, 22);
      lineButton.Text = "Line";
      lineButton.Click += LineButton_Click;
      // 
      // circleButton
      // 
      circleButton.Name = "circleButton";
      circleButton.Size = new Size(137, 22);
      circleButton.Text = "Circle";
      circleButton.Click += CircleButton_Click;
      // 
      // rectangleButton
      // 
      rectangleButton.Name = "rectangleButton";
      rectangleButton.Size = new Size(137, 22);
      rectangleButton.Text = "Rectangle";
      rectangleButton.Click += RectangleButton_Click;
      // 
      // polygonButton
      // 
      polygonButton.Name = "polygonButton";
      polygonButton.Size = new Size(137, 22);
      polygonButton.Text = "Polygon";
      polygonButton.Click += PolygonButton_Click;
      // 
      // bezierButton
      // 
      bezierButton.Name = "bezierButton";
      bezierButton.Size = new Size(137, 22);
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
      // edgeColorButton
      // 
      edgeColorButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
      edgeColorButton.Enabled = false;
      edgeColorButton.Image = (Image) resources.GetObject("edgeColorButton.Image");
      edgeColorButton.ImageTransparentColor = Color.Magenta;
      edgeColorButton.Name = "edgeColorButton";
      edgeColorButton.Size = new Size(67, 22);
      edgeColorButton.Text = "Edge color";
      edgeColorButton.Click += EdgeColorButton_Click;
      // 
      // fillColorButton
      // 
      fillColorButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
      fillColorButton.Enabled = false;
      fillColorButton.Image = (Image) resources.GetObject("fillColorButton.Image");
      fillColorButton.ImageTransparentColor = Color.Magenta;
      fillColorButton.Name = "fillColorButton";
      fillColorButton.Size = new Size(56, 22);
      fillColorButton.Text = "Fill color";
      fillColorButton.Click += FillColorButton_Click;
      // 
      // fillImageButton
      // 
      fillImageButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
      fillImageButton.Enabled = false;
      fillImageButton.Image = (Image) resources.GetObject("fillImageButton.Image");
      fillImageButton.ImageTransparentColor = Color.Magenta;
      fillImageButton.Name = "fillImageButton";
      fillImageButton.Size = new Size(88, 22);
      fillImageButton.Text = "Fill with image";
      fillImageButton.Click += FillImageButton_Click;
      // 
      // clearFillButton
      // 
      clearFillButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
      clearFillButton.Enabled = false;
      clearFillButton.Image = (Image) resources.GetObject("clearFillButton.Image");
      clearFillButton.ImageTransparentColor = Color.Magenta;
      clearFillButton.Name = "clearFillButton";
      clearFillButton.Size = new Size(54, 22);
      clearFillButton.Text = "Clear fill";
      clearFillButton.Click += ClearFillButton_Click;
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
      thicknessTextBox.Size = new Size(50, 25);
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
      // fileDropdownButton
      // 
      fileDropdownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
      fileDropdownButton.DropDownItems.AddRange(new ToolStripItem[] { loadButton, saveButton, clearButton });
      fileDropdownButton.Image = (Image) resources.GetObject("fileDropdownButton.Image");
      fileDropdownButton.ImageTransparentColor = Color.Magenta;
      fileDropdownButton.Name = "fileDropdownButton";
      fileDropdownButton.Size = new Size(38, 22);
      fileDropdownButton.Text = "File";
      // 
      // loadButton
      // 
      loadButton.Name = "loadButton";
      loadButton.Size = new Size(180, 22);
      loadButton.Text = "Load";
      loadButton.Click += LoadButton_Click;
      // 
      // saveButton
      // 
      saveButton.Name = "saveButton";
      saveButton.Size = new Size(180, 22);
      saveButton.Text = "Save";
      saveButton.Click += SaveButton_Click;
      // 
      // clearButton
      // 
      clearButton.Name = "clearButton";
      clearButton.Size = new Size(180, 22);
      clearButton.Text = "Clear";
      clearButton.Click += ClearButton_Click;
      // 
      // clipButton
      // 
      clipButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
      clipButton.Enabled = false;
      clipButton.Image = (Image) resources.GetObject("clipButton.Image");
      clipButton.ImageTransparentColor = Color.Magenta;
      clipButton.Name = "clipButton";
      clipButton.Size = new Size(97, 22);
      clipButton.Text = "Choose clipping";
      clipButton.Click += ClipButton_Click;
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
    private ToolStripButton antialiasingButton;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripButton deleteButton;
    private ToolStripButton edgeColorButton;
    private ToolStripLabel thicknessLabel;
    private PictureBox canvas;
    private ToolStripTextBox thicknessTextBox;
    private ToolStripButton fillColorButton;
    private ToolStripSplitButton addButton;
    private ToolStripDropDownButton drawDropdownButton;
    private ToolStripMenuItem lineButton;
    private ToolStripMenuItem circleButton;
    private ToolStripMenuItem rectangleButton;
    private ToolStripMenuItem polygonButton;
    private ToolStripMenuItem bezierButton;
    private ToolStripButton clearFillButton;
    private ToolStripButton fillImageButton;
    private ToolStripDropDownButton fileDropdownButton;
    private ToolStripMenuItem loadButton;
    private ToolStripMenuItem saveButton;
    private ToolStripMenuItem clearButton;
    private ToolStripButton clipButton;
  }
}