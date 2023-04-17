using System.Xml;

namespace rasterization {
  public abstract class Shape {
    public static readonly int Epsilon = 5;

    virtual public Color Color { get; set; }
    virtual public int Thickness { get; set; }

    public Shape() {
      Color = Color.Black;
      Thickness = 1;
    }

    public abstract void Draw(ImageByteArray imageByteArray, bool antialiasing);

    public abstract Shape? CheckColision(Point point);

    public abstract Point GetCenter();

    public abstract void Move(int dx, int dy);

    public abstract bool Edit(Point position, int dx, int dy);

    protected XmlElement CreateXmlElement(XmlDocument doc, string name) {
      XmlElement element = doc.CreateElement(name);
      element.SetAttribute("Color", ColorTranslator.ToHtml(Color));
      element.SetAttribute("Thickness", Thickness.ToString());
      return element;
    }

    public abstract XmlElement ToXmlElement(XmlDocument doc);

    public new string ToString() {
      XmlDocument doc = new();
      doc.AppendChild(ToXmlElement(doc));
      return doc.OuterXml;
    }

    protected void SetAttributesFromXml(XmlElement element) {
      if (!int.TryParse(element.GetAttribute("Thickness"), out int thickness))
        thickness = 1;
      Thickness = thickness;

      Color = ColorTranslator.FromHtml(element.GetAttribute("Color"));
    }
  }
}
