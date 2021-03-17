using ByteCrusher.Addition;
using ByteCrusher.Entities;

namespace ByteCrusher.UI
{
  public abstract class Text : Entity
  {
    private TextDrawer TextDrawer => Drawer as TextDrawer;

    protected string Value
    {
      set => TextDrawer.Text = value;
    }

    protected string Color
    {
      set => TextDrawer.Color = value;
    }

    protected string BackgroundColor
    {
      set => TextDrawer.BackgroundColor = value;
    }

    protected Text()
      => Drawer = new TextDrawer();
  }

  internal class TextDrawer : IEntityDrawer
  {
    internal string Text;
    internal string Color;
    internal string BackgroundColor;

    private readonly AsciiCode _asciiCode;

    internal TextDrawer()
      => _asciiCode = new AsciiCode();

    public string Code()
      => Text;

    public string Replace(string element)
      => Color != null || BackgroundColor != null
        ? _asciiCode
          .AddDrawing(element)
          .AddColorToAll(Color, BackgroundColor)
          .Build()
        : element;
  }
}