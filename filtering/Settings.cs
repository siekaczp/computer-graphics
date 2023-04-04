using System;
using System.Windows.Forms;

namespace filtering {
  public partial class Settings : Form {
    private int numberOfColors;
    private int colorsPerChannel;
    private int pixelSize;

    public Settings() {
      InitializeComponent();

      numberOfColors = Filters.popularityQuantizationFilter.K;
      colorsPerChannel = Filters.ditheringFilter.ColorsPerChannel;
      pixelSize = Filters.pixelateFilter.PixelSize;

      colorsQuantizationTextBox.Text = numberOfColors.ToString();
      colorValuesTextBox.Text = colorsPerChannel.ToString();
      pixelSizeTextBox.Text = pixelSize.ToString();

      sizeComboBox.SelectedItem = Filters.ditheringFilter.MapSize.ToString();
    }

    private void SaveButton_Click(object sender, EventArgs e) {
      Filters.popularityQuantizationFilter.K = numberOfColors;
      Filters.ditheringFilter.ColorsPerChannel = colorsPerChannel;
      Filters.ditheringFilter.MapSize = int.Parse(sizeComboBox.SelectedItem.ToString());
      Filters.pixelateFilter.PixelSize = pixelSize;
      Close();
    }

    private void CancelButton_Click(object sender, EventArgs e) {
      Close();
    }

    private void ColorsQuantizationTextBox_TextChanged(object sender, EventArgs e) {
      if (!int.TryParse(colorsQuantizationTextBox.Text, out int result) || result <= 0)
        result = 5;
      numberOfColors = result;
    }

    private void ColorValuesTextBox_TextChanged(object sender, EventArgs e) {
      if (!int.TryParse(colorValuesTextBox.Text, out int result) || result <= 0)
        result = 2;
      colorsPerChannel = result;
    }

    private void PixelSizeTextBox_TextChanged(object sender, EventArgs e) {
      if (!int.TryParse(pixelSizeTextBox.Text, out int result) || result <= 0)
        result = 16;
      pixelSize = result;
    }
  }
}
