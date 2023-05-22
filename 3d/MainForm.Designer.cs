namespace _3d {
  partial class MainForm {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      toolStrip = new ToolStrip();
      canvas = new PictureBox();
      spinButton = new ToolStripButton();
      toolStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize) canvas).BeginInit();
      SuspendLayout();
      // 
      // toolStrip
      // 
      toolStrip.Items.AddRange(new ToolStripItem[] { spinButton });
      toolStrip.Location = new Point(0, 0);
      toolStrip.Name = "toolStrip";
      toolStrip.Size = new Size(800, 25);
      toolStrip.TabIndex = 0;
      toolStrip.Text = "toolStrip1";
      // 
      // canvas
      // 
      canvas.Dock = DockStyle.Fill;
      canvas.Location = new Point(0, 25);
      canvas.Name = "canvas";
      canvas.Size = new Size(800, 425);
      canvas.TabIndex = 1;
      canvas.TabStop = false;
      // 
      // spinButton
      // 
      spinButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
      spinButton.Image = (Image) resources.GetObject("spinButton.Image");
      spinButton.ImageTransparentColor = Color.Magenta;
      spinButton.Name = "spinButton";
      spinButton.Size = new Size(34, 22);
      spinButton.Text = "Spin";
      spinButton.Click += SpinButton_Click;
      // 
      // MainForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(800, 450);
      Controls.Add(canvas);
      Controls.Add(toolStrip);
      MaximizeBox = false;
      Name = "MainForm";
      Text = "3D graphics Piotr Sieczka";
      toolStrip.ResumeLayout(false);
      toolStrip.PerformLayout();
      ((System.ComponentModel.ISupportInitialize) canvas).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private ToolStrip toolStrip;
    private PictureBox canvas;
    private ToolStripButton spinButton;
  }
}