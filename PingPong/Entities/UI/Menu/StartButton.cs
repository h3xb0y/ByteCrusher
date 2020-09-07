using ByteCrusher.Addition;
using ByteCrusher.Entities;

namespace PingPong.Entities.UI.Menu
{
  public class StartButton : Entity, IMenuElement
  {
    private readonly ButtonDrawer _textDrawer;

    public StartButton()
      => _textDrawer = new ButtonDrawer();

    public override IEntityDrawer Drawer()
      => _textDrawer;

    public void SetSelected(bool selected)
      => _textDrawer.IsSelected = selected;
  }

  internal class ButtonDrawer : IEntityDrawer
  {
    private readonly AsciiCode _asciiCode;

    private bool _isSelected;

    internal bool IsSelected
    {
      set => _isSelected = value;
    }

    public ButtonDrawer()
      => _asciiCode = new AsciiCode();

    public string Code()
      => "START ";

    public string Replace(string element)
      => _asciiCode
        .AddDrawing(element)
        .AddColor("S", "100", _isSelected ? "90" : "50")
        .AddColor("T", "100", _isSelected ? "90" : "50")
        .AddColor("A", "100", _isSelected ? "90" : "50")
        .AddColor("R", "100", _isSelected ? "90" : "50")
        .AddColor("T", "100", _isSelected ? "90" : "50")
        .Build();
  }
}