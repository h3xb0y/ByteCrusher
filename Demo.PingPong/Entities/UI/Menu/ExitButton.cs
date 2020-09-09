using ByteCrusher.Addition;
using ByteCrusher.Data;
using ByteCrusher.Entities;

namespace PingPong.Entities.UI.Menu
{
  public class ExitButton : Entity, IMenuElement
  {
    private readonly ExitDrawer _exitDrawer;

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

    public void SetSelected(bool selected)
      => _exitDrawer.IsSelected = selected;
  }

  internal class ExitDrawer : IEntityDrawer
  {
    private readonly AsciiCode _asciiCode;

    private bool _isSelected;

    internal bool IsSelected
    {
      set => _isSelected = value;
    }

    public ExitDrawer()
      => _asciiCode = new AsciiCode();

    public string Code()
      => "EXIT ";

    public string Replace(string element)
      => _asciiCode
        .AddDrawing(element)
        .AddColor("E", "100", _isSelected ? "90" : "50")
        .AddColor("X", "100", _isSelected ? "90" : "50")
        .AddColor("I", "100", _isSelected ? "90" : "50")
        .AddColor("T", "100", _isSelected ? "90" : "50")
        .Build();
  }
}