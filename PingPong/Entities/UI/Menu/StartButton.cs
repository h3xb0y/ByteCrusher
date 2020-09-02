using ByteCrusher.Addition;
using ByteCrusher.Entities;

namespace PingPong.Entities.UI.Menu
{
  public class StartButton : Entity
  {
    private readonly IEntityDrawer _textDrawer;
    
    private bool _isSelected;
    public bool IsSelected
    {
      set => _isSelected = value;
    }
    
    public StartButton()
      => _textDrawer = new ButtonDrawer();

    public override IEntityDrawer Drawer()
      => _textDrawer;
  }

  internal class ButtonDrawer : IEntityDrawer
  {
    private readonly AsciiCode _asciiCode;
    public ButtonDrawer()
    {
      _asciiCode = new AsciiCode()
        .AddColor("S", "100", "90")
        .AddColor("T", "100", "90")
        .AddColor("A", "100", "90")
        .AddColor("R", "100", "90")
        .AddColor("T", "100", "90");
    }
    
    public string Code()
      => "START ";

    public string Replace(string element)
      => _asciiCode
        .AddDrawing(element)
        .Build();
  }
}