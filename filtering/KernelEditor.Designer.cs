
namespace filtering {
  partial class KernelEditor {
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
      this.closeButton = new System.Windows.Forms.Button();
      this.colsTrackBar = new System.Windows.Forms.TrackBar();
      this.rowsTrackBar = new System.Windows.Forms.TrackBar();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.automaticDivisor = new System.Windows.Forms.CheckBox();
      this.label3 = new System.Windows.Forms.Label();
      this.divisorTextBox = new System.Windows.Forms.TextBox();
      this.kernelInputPanel = new System.Windows.Forms.TableLayoutPanel();
      this.saveButton = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.offsetTextBox = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.anchorXTextBox = new System.Windows.Forms.TextBox();
      this.anchorYTextBox = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.filtersComboBox = new System.Windows.Forms.ComboBox();
      this.newFilterTextBox = new System.Windows.Forms.TextBox();
      this.addFilterButton = new System.Windows.Forms.Button();
      this.removeButton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.colsTrackBar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.rowsTrackBar)).BeginInit();
      this.SuspendLayout();
      // 
      // closeButton
      // 
      this.closeButton.Location = new System.Drawing.Point(544, 379);
      this.closeButton.Name = "closeButton";
      this.closeButton.Size = new System.Drawing.Size(75, 23);
      this.closeButton.TabIndex = 0;
      this.closeButton.Text = "Close";
      this.closeButton.UseVisualStyleBackColor = true;
      this.closeButton.Click += new System.EventHandler(this.Close_Click);
      // 
      // colsTrackBar
      // 
      this.colsTrackBar.LargeChange = 1;
      this.colsTrackBar.Location = new System.Drawing.Point(262, 21);
      this.colsTrackBar.Maximum = 5;
      this.colsTrackBar.Minimum = 1;
      this.colsTrackBar.Name = "colsTrackBar";
      this.colsTrackBar.Size = new System.Drawing.Size(104, 45);
      this.colsTrackBar.TabIndex = 2;
      this.colsTrackBar.Value = 2;
      this.colsTrackBar.ValueChanged += new System.EventHandler(this.ColsTrackBar_ValueChanged);
      // 
      // rowsTrackBar
      // 
      this.rowsTrackBar.LargeChange = 1;
      this.rowsTrackBar.Location = new System.Drawing.Point(262, 63);
      this.rowsTrackBar.Maximum = 5;
      this.rowsTrackBar.Minimum = 1;
      this.rowsTrackBar.Name = "rowsTrackBar";
      this.rowsTrackBar.Size = new System.Drawing.Size(104, 45);
      this.rowsTrackBar.TabIndex = 3;
      this.rowsTrackBar.Value = 2;
      this.rowsTrackBar.ValueChanged += new System.EventHandler(this.RowsTrackBar_ValueChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(152, 27);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(104, 15);
      this.label1.TabIndex = 4;
      this.label1.Text = "Columns of kernel";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(152, 63);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(84, 15);
      this.label2.TabIndex = 5;
      this.label2.Text = "Rows of kernel";
      // 
      // automaticDivisor
      // 
      this.automaticDivisor.Location = new System.Drawing.Point(372, 5);
      this.automaticDivisor.Name = "automaticDivisor";
      this.automaticDivisor.Size = new System.Drawing.Size(134, 43);
      this.automaticDivisor.TabIndex = 6;
      this.automaticDivisor.Text = "Automatically compute divisor";
      this.automaticDivisor.UseVisualStyleBackColor = true;
      this.automaticDivisor.CheckedChanged += new System.EventHandler(this.AutomaticDivisor_CheckedChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(372, 51);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(78, 15);
      this.label3.TabIndex = 7;
      this.label3.Text = "Kernel divisor";
      // 
      // divisorTextBox
      // 
      this.divisorTextBox.Location = new System.Drawing.Point(456, 48);
      this.divisorTextBox.Name = "divisorTextBox";
      this.divisorTextBox.Size = new System.Drawing.Size(50, 23);
      this.divisorTextBox.TabIndex = 8;
      this.divisorTextBox.Text = "1";
      this.divisorTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.divisorTextBox.TextChanged += new System.EventHandler(this.DivisorTextBox_TextChanged);
      // 
      // kernelInputPanel
      // 
      this.kernelInputPanel.ColumnCount = 2;
      this.kernelInputPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.kernelInputPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.kernelInputPanel.Location = new System.Drawing.Point(12, 106);
      this.kernelInputPanel.Name = "kernelInputPanel";
      this.kernelInputPanel.RowCount = 2;
      this.kernelInputPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.kernelInputPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.kernelInputPanel.Size = new System.Drawing.Size(607, 267);
      this.kernelInputPanel.TabIndex = 9;
      // 
      // saveButton
      // 
      this.saveButton.Location = new System.Drawing.Point(463, 379);
      this.saveButton.Name = "saveButton";
      this.saveButton.Size = new System.Drawing.Size(75, 23);
      this.saveButton.TabIndex = 10;
      this.saveButton.Text = "Save";
      this.saveButton.UseVisualStyleBackColor = true;
      this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(372, 77);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(73, 15);
      this.label4.TabIndex = 11;
      this.label4.Text = "Kernel offset";
      // 
      // offsetTextBox
      // 
      this.offsetTextBox.Location = new System.Drawing.Point(456, 74);
      this.offsetTextBox.Name = "offsetTextBox";
      this.offsetTextBox.Size = new System.Drawing.Size(50, 23);
      this.offsetTextBox.TabIndex = 12;
      this.offsetTextBox.Text = "0";
      this.offsetTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.offsetTextBox.TextChanged += new System.EventHandler(this.OffsetTextBox_TextChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(512, 18);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(107, 15);
      this.label5.TabIndex = 13;
      this.label5.Text = "Location of anchor";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(512, 51);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(50, 15);
      this.label6.TabIndex = 14;
      this.label6.Text = "Column";
      // 
      // anchorXTextBox
      // 
      this.anchorXTextBox.Location = new System.Drawing.Point(569, 48);
      this.anchorXTextBox.Name = "anchorXTextBox";
      this.anchorXTextBox.Size = new System.Drawing.Size(50, 23);
      this.anchorXTextBox.TabIndex = 15;
      this.anchorXTextBox.Text = "1";
      this.anchorXTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.anchorXTextBox.TextChanged += new System.EventHandler(this.AnchorXTextBox_TextChanged);
      // 
      // anchorYTextBox
      // 
      this.anchorYTextBox.Location = new System.Drawing.Point(569, 77);
      this.anchorYTextBox.Name = "anchorYTextBox";
      this.anchorYTextBox.Size = new System.Drawing.Size(50, 23);
      this.anchorYTextBox.TabIndex = 16;
      this.anchorYTextBox.Text = "1";
      this.anchorYTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.anchorYTextBox.TextChanged += new System.EventHandler(this.AnchorYTextBox_TextChanged);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(512, 80);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(30, 15);
      this.label7.TabIndex = 17;
      this.label7.Text = "Row";
      // 
      // filtersComboBox
      // 
      this.filtersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.filtersComboBox.FormattingEnabled = true;
      this.filtersComboBox.Location = new System.Drawing.Point(12, 19);
      this.filtersComboBox.Name = "filtersComboBox";
      this.filtersComboBox.Size = new System.Drawing.Size(134, 23);
      this.filtersComboBox.TabIndex = 20;
      this.filtersComboBox.SelectedIndexChanged += new System.EventHandler(this.FiltersComboBox_SelectedIndexChanged);
      // 
      // newFilterTextBox
      // 
      this.newFilterTextBox.Location = new System.Drawing.Point(12, 49);
      this.newFilterTextBox.Name = "newFilterTextBox";
      this.newFilterTextBox.Size = new System.Drawing.Size(81, 23);
      this.newFilterTextBox.TabIndex = 21;
      // 
      // addFilterButton
      // 
      this.addFilterButton.Location = new System.Drawing.Point(100, 48);
      this.addFilterButton.Name = "addFilterButton";
      this.addFilterButton.Size = new System.Drawing.Size(46, 23);
      this.addFilterButton.TabIndex = 22;
      this.addFilterButton.Text = "Add";
      this.addFilterButton.UseVisualStyleBackColor = true;
      this.addFilterButton.Click += new System.EventHandler(this.AddFilterButton_Click);
      // 
      // removeButton
      // 
      this.removeButton.Location = new System.Drawing.Point(12, 77);
      this.removeButton.Name = "removeButton";
      this.removeButton.Size = new System.Drawing.Size(134, 23);
      this.removeButton.TabIndex = 23;
      this.removeButton.Text = "Remove";
      this.removeButton.UseVisualStyleBackColor = true;
      this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
      // 
      // KernelEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(633, 412);
      this.ControlBox = false;
      this.Controls.Add(this.removeButton);
      this.Controls.Add(this.addFilterButton);
      this.Controls.Add(this.newFilterTextBox);
      this.Controls.Add(this.filtersComboBox);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.anchorYTextBox);
      this.Controls.Add(this.anchorXTextBox);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.offsetTextBox);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.saveButton);
      this.Controls.Add(this.kernelInputPanel);
      this.Controls.Add(this.divisorTextBox);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.automaticDivisor);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.rowsTrackBar);
      this.Controls.Add(this.colsTrackBar);
      this.Controls.Add(this.closeButton);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "KernelEditor";
      this.Text = "Kernel editor";
      this.Shown += new System.EventHandler(this.KernelEditor_Shown);
      ((System.ComponentModel.ISupportInitialize)(this.colsTrackBar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.rowsTrackBar)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button closeButton;
    private System.Windows.Forms.TrackBar colsTrackBar;
    private System.Windows.Forms.TrackBar rowsTrackBar;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.CheckBox automaticDivisor;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox divisorTextBox;
    private System.Windows.Forms.TableLayoutPanel kernelInputPanel;
    private System.Windows.Forms.Button saveButton;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox offsetTextBox;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox anchorXTextBox;
    private System.Windows.Forms.TextBox anchorYTextBox;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.ComboBox filtersComboBox;
    private System.Windows.Forms.TextBox newFilterTextBox;
    private System.Windows.Forms.Button addFilterButton;
    private System.Windows.Forms.Button removeButton;
  }
}