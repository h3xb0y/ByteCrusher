using ByteCrusher.Addition;
using ByteCrusher.Data;
using ByteCrusher.Entities;

namespace PingPong.Entities.UI.Menu
{
  public class ExitButton : Entity
  {
    private readonly ExitDrawer _exitDrawer;
    
    private bool _isSelected;
    public bool IsSelected
    {
      set => _isSelected = value;
    }

    public ExitButton()
    {
      _exitDrawer = new ExitDrawer();
      
      Position = new Position
      {
        X = 15,
        Y = 2
      };
    }

    public override IEntityDrawer Drawer()
      => _exitDrawer;
  }

  internal class ExitDrawer : IEntityDrawer
  {
    private readonly AsciiCode _asciiCode;
    public ExitDrawer()
    {
      _asciiCode = new AsciiCode()
        .AddColor("E", "100", "90")
        .AddColor("X", "100", "90")
        .AddColor("I", "100", "90")
        .AddColor("T", "100", "90");
    }
    
    public string Code()
      => "EXIT ";

    public string Replace(string element)
      => _asciiCode
        .AddDrawing(element)
        .Build();
  }
}