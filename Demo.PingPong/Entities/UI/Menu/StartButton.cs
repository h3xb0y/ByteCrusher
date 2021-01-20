using ByteCrusher.Addition;
using ByteCrusher.Entities;

namespace PingPong.Entities.UI.Menu
{
  public class StartButton : Entity, IMenuElement
  {
    private ButtonDrawer _textDrawer => Drawer as ButtonDrawer;

    public StartButton()
    {
      Drawer = new ButtonDrawer();
    }

    public bool GetSelected()
      => _textDrawer.IsSelected;

    public void SetSelected(bool selected)
      => _textDrawer.IsSelected = selected;
  }

  internal class ButtonDrawer : IEntityDrawer
  {
    private readonly AsciiCode _asciiCode;

    internal bool IsSelected;

    public ButtonDrawer()
      => _asciiCode = new AsciiCode();

    public string Code()
      => "START ";

    public string Replace(string element)
      => _asciiCode
        .AddDrawing(element)
        .AddColor("S", "100", IsSelected ? "90" : "50")
        .AddColor("T", "100", IsSelected ? "90" : "50")
        .AddColor("A", "100", IsSelected ? "90" : "50")
        .AddColor("R", "100", IsSelected ? "90" : "50")
        .AddColor("T", "100", IsSelected ? "90" : "50")
        .Build();
  }
}