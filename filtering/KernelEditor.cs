using System;
using System.Linq;
using System.Windows.Forms;

namespace filtering {
  public partial class KernelEditor : Form {
    private ConvolutionFilter filter;

    public KernelEditor() {
      InitializeComponent();
    }

    private void KernelEditor_Shown(object sender, EventArgs e) {
      filtersComboBox.Items.AddRange(Filters.ConvolutionFilters.Keys.ToArray());
      filtersComboBox.SelectedIndex = 0;
    }

    private void FiltersComboBox_SelectedIndexChanged(object sender, EventArgs e) {
      filter = Filters.ConvolutionFilters[filtersComboBox.SelectedItem as string].Clone();

      divisorTextBox.Text = filter.Divisor.ToString();
      offsetTextBox.Text = filter.Offset.ToString();
      kernelInputPanel.RowCount = filter.Rows;
      kernelInputPanel.ColumnCount = filter.Cols;

      int anchorX = filter.AnchorX;
      int anchorY = filter.AnchorY;

      rowsTrackBar.Value = (kernelInputPanel.RowCount + 1) / 2;
      colsTrackBar.Value = (kernelInputPanel.ColumnCount + 1) / 2;
      anchorXTextBox.Text = anchorX.ToString();
      anchorYTextBox.Text = anchorY.ToString();

      FillKernelInput();
    }

    private void FillKernelInput() {
      kernelInputPanel.Controls.Clear();

      for (int i = 0; i < kernelInputPanel.RowCount; i++) {
        for (int j = 0; j < kernelInputPanel.ColumnCount; j++) {
          TextBox input = new() {
            Width = 50,
            Text = filter.Kernel[i, j].ToString()
          };
          int localI = i;
          int localJ = j;
          input.TextChanged += (object sender, EventArgs e) => KernelInputChanged((sender as TextBox).Text, localI, localJ);
          kernelInputPanel.Controls.Add(input);
        }
      }
    }

    private void KernelInputChanged(string input, int i, int j) {
      if (!int.TryParse(input, out int result))
        result = 1;
      filter.Kernel[i, j] = result;
    }

    private void Close_Click(object sender, EventArgs e) {
      Close();
    }

    private void SaveButton_Click(object sender, EventArgs e) {
      Filters.ConvolutionFilters[filtersComboBox.SelectedItem as string] = filter;
    }

    private void ColsTrackBar_ValueChanged(object sender, EventArgs e) {
      int newCols = 2 * (sender as TrackBar).Value - 1;
      int minCols = Math.Min(newCols, filter.Cols);
      int[,] newKernel = new int[filter.Rows, newCols];

      for (int i = 0; i < filter.Rows; i++)
        for (int j = 0; j < minCols; j++)
          newKernel[i, j] = filter.Kernel[i, j];

      filter.Kernel = newKernel;
      filter.AnchorX = filter.Cols / 2;
      anchorXTextBox.Text = filter.AnchorX.ToString();
      kernelInputPanel.ColumnCount = filter.Cols;
      FillKernelInput();
    }

    private void RowsTrackBar_ValueChanged(object sender, EventArgs e) {
      int newRows = 2 * (sender as TrackBar).Value - 1;
      int minRows = Math.Min(newRows, filter.Rows);
      int[,] newKernel = new int[newRows, filter.Cols];

      for (int i = 0; i < minRows; i++)
        for (int j = 0; j < filter.Cols; j++)
          newKernel[i, j] = filter.Kernel[i, j];

      filter.Kernel = newKernel;
      filter.AnchorY = filter.Rows / 2;
      anchorYTextBox.Text = filter.AnchorY.ToString();
      kernelInputPanel.RowCount = filter.Rows;
      FillKernelInput();
    }

    private void AutomaticDivisor_CheckedChanged(object sender, EventArgs e) {
      if ((sender as CheckBox).Checked) {
        divisorTextBox.Enabled = false;
        filter.CalculateDivisor();
        divisorTextBox.Text = filter.Divisor.ToString();
      } else {
        divisorTextBox.Enabled = true;
        DivisorTextBox_TextChanged(sender, e);
      }
    }

    private void DivisorTextBox_TextChanged(object sender, EventArgs e) {
      if (!int.TryParse(divisorTextBox.Text, out int result) || result == 0)
        result = 1;
      filter.Divisor = result;
    }

    private void OffsetTextBox_TextChanged(object sender, EventArgs e) {
      if (!int.TryParse(offsetTextBox.Text, out int result))
        result = 0;
      filter.Offset = result;
    }

    private void AnchorXTextBox_TextChanged(object sender, EventArgs e) {
      if (!int.TryParse(anchorXTextBox.Text, out int result) || result < 0 || result >= filter.Cols)
        result = filter.Cols / 2;
      filter.AnchorX = result;
    }

    private void AnchorYTextBox_TextChanged(object sender, EventArgs e) {
      if (!int.TryParse(anchorYTextBox.Text, out int result) || result < 0 || result >= filter.Rows)
        result = filter.Rows / 2;
      filter.AnchorY = result;
    }

    private void AddFilterButton_Click(object sender, EventArgs e) {
      string newFilterName = newFilterTextBox.Text.Trim();
      if (newFilterName.Length == 0 || Filters.ConvolutionFilters.ContainsKey(newFilterName))
        return;

      AddFilter(newFilterName);
    }

    private void AddFilter(string newFilterName) {
      ConvolutionFilter newFilter = new(new int[3, 3] {
        { 0, 0, 0 },
        { 0, 1, 0 },
        { 0, 0, 0 },
      });

      Filters.ConvolutionFilters.Add(newFilterName, newFilter);

      newFilterTextBox.Text = "";
      filtersComboBox.Items.Add(newFilterName);
      filtersComboBox.SelectedItem = newFilterName;
      (Owner as MainWindow).AddFilterToMenu(newFilterName);
    }

    private void RemoveButton_Click(object sender, EventArgs e) {
      string filter = filtersComboBox.SelectedItem as string;
      filtersComboBox.Items.RemoveAt(filtersComboBox.SelectedIndex);
      (Owner as MainWindow).RemoveFilterFromMenu(filter);
      Filters.ConvolutionFilters.Remove(filter);

      if (Filters.ConvolutionFilters.Count == 0)
        AddFilter("Identity");

      filtersComboBox.SelectedIndex = 0;
    }
  }
}
