
namespace filtering {
  partial class Settings {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.label1 = new System.Windows.Forms.Label();
      this.colorsQuantizationTextBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.colorValuesTextBox = new System.Windows.Forms.TextBox();
      this.saveButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.sizeComboBox = new System.Windows.Forms.ComboBox();
      this.label7 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.pixelSizeTextBox = new System.Windows.Forms.TextBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(6, 33);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(100, 15);
      this.label1.TabIndex = 0;
      this.label1.Text = "Number of colors";
      // 
      // colorsQuantizationTextBox
      // 
      this.colorsQuantizationTextBox.Location = new System.Drawing.Point(133, 26);
      this.colorsQuantizationTextBox.Name = "colorsQuantizationTextBox";
      this.colorsQuantizationTextBox.Size = new System.Drawing.Size(104, 23);
      this.colorsQuantizationTextBox.TabIndex = 1;
      this.colorsQuantizationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.colorsQuantizationTextBox.TextChanged += new System.EventHandler(this.ColorsQuantizationTextBox_TextChanged);
      // 
      // label2
      // 
      this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.label2.Location = new System.Drawing.Point(6, 26);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(114, 53);
      this.label2.TabIndex = 3;
      this.label2.Text = "Number of color values per channel";
      // 
      // label5
      // 
      this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.label5.Location = new System.Drawing.Point(6, 59);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(100, 41);
      this.label5.TabIndex = 6;
      this.label5.Text = "Size of the threshold map";
      // 
      // colorValuesTextBox
      // 
      this.colorValuesTextBox.Location = new System.Drawing.Point(133, 26);
      this.colorValuesTextBox.Name = "colorValuesTextBox";
      this.colorValuesTextBox.Size = new System.Drawing.Size(104, 23);
      this.colorValuesTextBox.TabIndex = 7;
      this.colorValuesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.colorValuesTextBox.TextChanged += new System.EventHandler(this.ColorValuesTextBox_TextChanged);
      // 
      // saveButton
      // 
      this.saveButton.Location = new System.Drawing.Point(99, 263);
      this.saveButton.Name = "saveButton";
      this.saveButton.Size = new System.Drawing.Size(75, 23);
      this.saveButton.TabIndex = 8;
      this.saveButton.Text = "Save";
      this.saveButton.UseVisualStyleBackColor = true;
      this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Location = new System.Drawing.Point(180, 263);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 9;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // sizeComboBox
      // 
      this.sizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.sizeComboBox.FormattingEnabled = true;
      this.sizeComboBox.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "6"});
      this.sizeComboBox.Location = new System.Drawing.Point(133, 59);
      this.sizeComboBox.Name = "sizeComboBox";
      this.sizeComboBox.Size = new System.Drawing.Size(104, 23);
      this.sizeComboBox.TabIndex = 10;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.label7.Location = new System.Drawing.Point(6, 33);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(54, 15);
      this.label7.TabIndex = 12;
      this.label7.Text = "Pixel size";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.pixelSizeTextBox);
      this.groupBox1.Controls.Add(this.label7);
      this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(243, 64);
      this.groupBox1.TabIndex = 13;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Pixelate";
      // 
      // pixelSizeTextBox
      // 
      this.pixelSizeTextBox.Location = new System.Drawing.Point(133, 26);
      this.pixelSizeTextBox.Name = "pixelSizeTextBox";
      this.pixelSizeTextBox.Size = new System.Drawing.Size(104, 23);
      this.pixelSizeTextBox.TabIndex = 13;
      this.pixelSizeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.pixelSizeTextBox.TextChanged += new System.EventHandler(this.PixelSizeTextBox_TextChanged);
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.sizeComboBox);
      this.groupBox2.Controls.Add(this.colorValuesTextBox);
      this.groupBox2.Controls.Add(this.label5);
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.groupBox2.Location = new System.Drawing.Point(12, 155);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(243, 102);
      this.groupBox2.TabIndex = 14;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Dithering";
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.colorsQuantizationTextBox);
      this.groupBox3.Controls.Add(this.label1);
      this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.groupBox3.Location = new System.Drawing.Point(12, 82);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(243, 67);
      this.groupBox3.TabIndex = 15;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Color quantization";
      // 
      // Settings
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(267, 296);
      this.ControlBox = false;
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.saveButton);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "Settings";
      this.Text = "Settings";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox colorsQuantizationTextBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox colorValuesTextBox;
    private System.Windows.Forms.Button saveButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.ComboBox sizeComboBox;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox pixelSizeTextBox;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox groupBox3;
  }
}