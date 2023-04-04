
namespace filtering {
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
      toolStrip1 = new System.Windows.Forms.ToolStrip();
      fileDropDown = new System.Windows.Forms.ToolStripDropDownButton();
      loadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      reverseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      functionFiltersDropDown = new System.Windows.Forms.ToolStripDropDownButton();
      convolutionFiltersDropDown = new System.Windows.Forms.ToolStripDropDownButton();
      pixelateButton = new System.Windows.Forms.ToolStripButton();
      popularityQuantizationButton = new System.Windows.Forms.ToolStripButton();
      ditheringButton = new System.Windows.Forms.ToolStripButton();
      toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      toYCbCrButton = new System.Windows.Forms.ToolStripButton();
      toRGBButton = new System.Windows.Forms.ToolStripButton();
      toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      showKernelEditorButton = new System.Windows.Forms.ToolStripButton();
      settingsButton = new System.Windows.Forms.ToolStripButton();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      originalImageBox = new System.Windows.Forms.PictureBox();
      filteredImageBox = new System.Windows.Forms.PictureBox();
      label1 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      toolStrip1.SuspendLayout();
      tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize) originalImageBox).BeginInit();
      ((System.ComponentModel.ISupportInitialize) filteredImageBox).BeginInit();
      SuspendLayout();
      // 
      // toolStrip1
      // 
      toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileDropDown, toolStripSeparator1, functionFiltersDropDown, convolutionFiltersDropDown, pixelateButton, popularityQuantizationButton, ditheringButton, toolStripSeparator2, toYCbCrButton, toRGBButton, toolStripSeparator3, showKernelEditorButton, settingsButton });
      toolStrip1.Location = new System.Drawing.Point(0, 0);
      toolStrip1.Name = "toolStrip1";
      toolStrip1.Size = new System.Drawing.Size(800, 25);
      toolStrip1.TabIndex = 0;
      toolStrip1.Text = "toolStrip1";
      // 
      // fileDropDown
      // 
      fileDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      fileDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { loadMenuItem, saveMenuItem, reverseMenuItem });
      fileDropDown.Image = (System.Drawing.Image) resources.GetObject("fileDropDown.Image");
      fileDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
      fileDropDown.Name = "fileDropDown";
      fileDropDown.Size = new System.Drawing.Size(38, 22);
      fileDropDown.Text = "File";
      // 
      // loadMenuItem
      // 
      loadMenuItem.Name = "loadMenuItem";
      loadMenuItem.Size = new System.Drawing.Size(138, 22);
      loadMenuItem.Text = "Load image";
      loadMenuItem.Click += LoadButton_Click;
      // 
      // saveMenuItem
      // 
      saveMenuItem.Enabled = false;
      saveMenuItem.Name = "saveMenuItem";
      saveMenuItem.Size = new System.Drawing.Size(138, 22);
      saveMenuItem.Text = "Save image";
      saveMenuItem.Click += SaveButton_Click;
      // 
      // reverseMenuItem
      // 
      reverseMenuItem.Enabled = false;
      reverseMenuItem.Name = "reverseMenuItem";
      reverseMenuItem.Size = new System.Drawing.Size(138, 22);
      reverseMenuItem.Text = "Reset image";
      reverseMenuItem.Click += ReverseButton_Click;
      // 
      // toolStripSeparator1
      // 
      toolStripSeparator1.Name = "toolStripSeparator1";
      toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // functionFiltersDropDown
      // 
      functionFiltersDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      functionFiltersDropDown.Enabled = false;
      functionFiltersDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
      functionFiltersDropDown.Name = "functionFiltersDropDown";
      functionFiltersDropDown.Size = new System.Drawing.Size(99, 22);
      functionFiltersDropDown.Text = "Function filters";
      functionFiltersDropDown.DropDownItemClicked += FunctionFiltersDropDown_DropDownItemClicked;
      // 
      // convolutionFiltersDropDown
      // 
      convolutionFiltersDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      convolutionFiltersDropDown.Enabled = false;
      convolutionFiltersDropDown.Image = (System.Drawing.Image) resources.GetObject("convolutionFiltersDropDown.Image");
      convolutionFiltersDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
      convolutionFiltersDropDown.Name = "convolutionFiltersDropDown";
      convolutionFiltersDropDown.Size = new System.Drawing.Size(118, 22);
      convolutionFiltersDropDown.Text = "Convolution filters";
      convolutionFiltersDropDown.DropDownItemClicked += ConvolutionFiltersDropDown_DropDownItemClicked;
      // 
      // pixelateButton
      // 
      pixelateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      pixelateButton.Enabled = false;
      pixelateButton.Image = (System.Drawing.Image) resources.GetObject("pixelateButton.Image");
      pixelateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      pixelateButton.Name = "pixelateButton";
      pixelateButton.Size = new System.Drawing.Size(52, 22);
      pixelateButton.Text = "Pixelate";
      pixelateButton.Click += PixelateButton_Click;
      // 
      // popularityQuantizationButton
      // 
      popularityQuantizationButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      popularityQuantizationButton.Enabled = false;
      popularityQuantizationButton.Image = (System.Drawing.Image) resources.GetObject("popularityQuantizationButton.Image");
      popularityQuantizationButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      popularityQuantizationButton.Name = "popularityQuantizationButton";
      popularityQuantizationButton.Size = new System.Drawing.Size(79, 22);
      popularityQuantizationButton.Text = "Quantization";
      popularityQuantizationButton.Click += PopularityQuantizationButton_Click;
      // 
      // ditheringButton
      // 
      ditheringButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      ditheringButton.Enabled = false;
      ditheringButton.Image = (System.Drawing.Image) resources.GetObject("ditheringButton.Image");
      ditheringButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      ditheringButton.Name = "ditheringButton";
      ditheringButton.Size = new System.Drawing.Size(60, 22);
      ditheringButton.Text = "Dithering";
      ditheringButton.Click += DitheringButton_Click;
      // 
      // toolStripSeparator2
      // 
      toolStripSeparator2.Name = "toolStripSeparator2";
      toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
      // 
      // toYCbCrButton
      // 
      toYCbCrButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      toYCbCrButton.Enabled = false;
      toYCbCrButton.Image = (System.Drawing.Image) resources.GetObject("toYCbCrButton.Image");
      toYCbCrButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      toYCbCrButton.Name = "toYCbCrButton";
      toYCbCrButton.Size = new System.Drawing.Size(60, 22);
      toYCbCrButton.Text = "To YCbCr";
      toYCbCrButton.Click += ToYCbCrButton_Click;
      // 
      // toRGBButton
      // 
      toRGBButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      toRGBButton.Enabled = false;
      toRGBButton.Image = (System.Drawing.Image) resources.GetObject("toRGBButton.Image");
      toRGBButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      toRGBButton.Name = "toRGBButton";
      toRGBButton.Size = new System.Drawing.Size(48, 22);
      toRGBButton.Text = "To RGB";
      toRGBButton.Click += ToRGBButton_Click;
      // 
      // toolStripSeparator3
      // 
      toolStripSeparator3.Name = "toolStripSeparator3";
      toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
      // 
      // showKernelEditorButton
      // 
      showKernelEditorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      showKernelEditorButton.Image = (System.Drawing.Image) resources.GetObject("showKernelEditorButton.Image");
      showKernelEditorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      showKernelEditorButton.Name = "showKernelEditorButton";
      showKernelEditorButton.Size = new System.Drawing.Size(109, 22);
      showKernelEditorButton.Text = "Show kernel editor";
      showKernelEditorButton.Click += ShowKernelEditorButton_Click;
      // 
      // settingsButton
      // 
      settingsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      settingsButton.Image = (System.Drawing.Image) resources.GetObject("settingsButton.Image");
      settingsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      settingsButton.Name = "settingsButton";
      settingsButton.Size = new System.Drawing.Size(53, 22);
      settingsButton.Text = "Settings";
      settingsButton.Click += SettingsButton_Click;
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 2;
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      tableLayoutPanel1.Controls.Add(originalImageBox, 0, 1);
      tableLayoutPanel1.Controls.Add(filteredImageBox, 1, 1);
      tableLayoutPanel1.Controls.Add(label1, 0, 0);
      tableLayoutPanel1.Controls.Add(label2, 1, 0);
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 2;
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tableLayoutPanel1.Size = new System.Drawing.Size(800, 425);
      tableLayoutPanel1.TabIndex = 1;
      // 
      // originalImageBox
      // 
      originalImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
      originalImageBox.Location = new System.Drawing.Point(3, 23);
      originalImageBox.Name = "originalImageBox";
      originalImageBox.Size = new System.Drawing.Size(394, 399);
      originalImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      originalImageBox.TabIndex = 0;
      originalImageBox.TabStop = false;
      // 
      // filteredImageBox
      // 
      filteredImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
      filteredImageBox.Location = new System.Drawing.Point(403, 23);
      filteredImageBox.Name = "filteredImageBox";
      filteredImageBox.Size = new System.Drawing.Size(394, 399);
      filteredImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      filteredImageBox.TabIndex = 1;
      filteredImageBox.TabStop = false;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(3, 0);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(85, 15);
      label1.TabIndex = 2;
      label1.Text = "Original image";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(403, 0);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(82, 15);
      label2.TabIndex = 3;
      label2.Text = "Filtered image";
      // 
      // MainWindow
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(800, 450);
      Controls.Add(tableLayoutPanel1);
      Controls.Add(toolStrip1);
      Name = "MainWindow";
      Text = "Image filtering";
      toolStrip1.ResumeLayout(false);
      toolStrip1.PerformLayout();
      tableLayoutPanel1.ResumeLayout(false);
      tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize) originalImageBox).EndInit();
      ((System.ComponentModel.ISupportInitialize) filteredImageBox).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripDropDownButton functionFiltersDropDown;
    private System.Windows.Forms.ToolStripDropDownButton convolutionFiltersDropDown;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.PictureBox originalImageBox;
    private System.Windows.Forms.PictureBox filteredImageBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ToolStripButton showKernelEditorButton;
    private System.Windows.Forms.ToolStripButton pixelateButton;
    private System.Windows.Forms.ToolStripDropDownButton fileDropDown;
    private System.Windows.Forms.ToolStripMenuItem loadMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
    private System.Windows.Forms.ToolStripMenuItem reverseMenuItem;
    private System.Windows.Forms.ToolStripButton popularityQuantizationButton;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton ditheringButton;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripButton settingsButton;
    private System.Windows.Forms.ToolStripButton toYCbCrButton;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripButton toRGBButton;
  }
}

