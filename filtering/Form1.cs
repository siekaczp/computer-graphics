using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace filtering {
  public partial class MainWindow : Form {
    private Bitmap originalImage;
    private Bitmap filteredImage;
    private Rectangle originalImageRect;

    public MainWindow() {
      InitializeComponent();

      convolutionFiltersDropDown.DropDownItems.AddRange(Filters.ConvolutionFilters.Keys.Select(filterName =>
        new ToolStripMenuItem {
          Text = filterName,
          Name = filterName,
        }).ToArray());

      functionFiltersDropDown.DropDownItems.AddRange(Filters.FunctionFilters.Keys.Select(filterName =>
        new ToolStripMenuItem {
          Text = filterName,
          Name = filterName,
        }).ToArray());
    }

    private void ConvolutionFiltersDropDown_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e) {
      ApplyFilter(Filters.ConvolutionFilters[e.ClickedItem.Text]);
    }

    private void FunctionFiltersDropDown_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e) {
      ApplyFilter(Filters.FunctionFilters[e.ClickedItem.Text]);
    }

    public void AddFilterToMenu(string filterName) {
      convolutionFiltersDropDown.DropDownItems.Add(new ToolStripMenuItem {
        Text = filterName,
        Name = filterName,
      });
    }

    public void RemoveFilterFromMenu(string filterName) {
      convolutionFiltersDropDown.DropDownItems.RemoveByKey(filterName);
    }

    private void LoadButton_Click(object sender, EventArgs e) {
      OpenFileDialog openFileDialog = new() {
        Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG"
      };

      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;

      originalImage = new Bitmap(openFileDialog.FileName);
      originalImageRect = new Rectangle(0, 0, originalImage.Width, originalImage.Height);
      originalImageBox.Image = originalImage;

      CreateFilteredImage();

      saveMenuItem.Enabled = true;
      reverseMenuItem.Enabled = true;
      functionFiltersDropDown.Enabled = true;
      convolutionFiltersDropDown.Enabled = true;
      pixelateButton.Enabled = true;
      popularityQuantizationButton.Enabled = true;
      ditheringButton.Enabled = true;
      toYCbCrButton.Enabled = true;
    }

    private void SaveButton_Click(object sender, EventArgs e) {
      SaveFileDialog saveFileDialog = new() {
        Filter = ""
      };

      ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
      string sep = "";

      foreach (ImageCodecInfo c in codecs) {
        string codecName = c.CodecName[8..].Replace("Codec", "Files").Trim();
        saveFileDialog.Filter = string.Format("{0}{1}{2} ({3})|{3}", saveFileDialog.Filter, sep, codecName, c.FilenameExtension);
        sep = "|";
      }

      saveFileDialog.Filter = string.Format("{0}{1}{2} ({3})|{3}", saveFileDialog.Filter, sep, "All Files", "*.*");
      saveFileDialog.DefaultExt = ".png";

      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;

      filteredImage.Save(saveFileDialog.FileName);
    }

    private void CreateFilteredImage() {
      filteredImage?.Dispose();
      filteredImage = originalImage.Clone(originalImageRect, PixelFormat.Format24bppRgb);
      filteredImageBox.Image = filteredImage;
    }

    private void ReverseButton_Click(object sender, EventArgs e) {
      CreateFilteredImage();
      ditheringButton.Enabled = true;
      toYCbCrButton.Enabled = true;
    }

    private void ShowKernelEditorButton_Click(object sender, EventArgs e) {
      KernelEditor kernelEditor = new();
      kernelEditor.Show(this);
    }

    private void SettingsButton_Click(object sender, EventArgs e) {
      Settings settings = new();
      settings.Show(this);
    }

    private void ApplyFilter(IFilter filter) {
      string title = Text;
      Text = "Applying filter...";

      Rectangle rect = new(0, 0, filteredImage.Width, filteredImage.Height);
      BitmapData bmpData = filteredImage.LockBits(rect, ImageLockMode.ReadWrite, filteredImage.PixelFormat);

      IntPtr ptr = bmpData.Scan0;
      int bytes = Math.Abs(bmpData.Stride) * filteredImage.Height;
      byte[] rgbValues = new byte[bytes];

      Marshal.Copy(ptr, rgbValues, 0, bytes);
      filter.Apply(rgbValues, new BitmapInfo(filteredImage.Width, filteredImage.Height, bmpData.Stride));
      Marshal.Copy(rgbValues, 0, ptr, bytes);

      filteredImage.UnlockBits(bmpData);
      Text = title;
      filteredImageBox.Refresh();
    }

    private void PixelateButton_Click(object sender, EventArgs e) {
      ApplyFilter(Filters.pixelateFilter);
    }

    private void PopularityQuantizationButton_Click(object sender, EventArgs e) {
      ApplyFilter(Filters.popularityQuantizationFilter);
    }

    private void DitheringButton_Click(object sender, EventArgs e) {
      ApplyFilter(Filters.ditheringFilter);
    }

    private void ToYCbCrButton_Click(object sender, EventArgs e) {
      toRGBButton.Enabled = true;
      toYCbCrButton.Enabled = false;
      ApplyFilter(ColorConverter.ToYCbCr());
    }

    private void ToRGBButton_Click(object sender, EventArgs e) {
      toRGBButton.Enabled = false;
      toYCbCrButton.Enabled = true;
      ApplyFilter(ColorConverter.ToRGB());
    }
  }
}
