using ByteCrusher.Addition;
using ByteCrusher.Data;
using ByteCrusher.Entities;

namespace PingPong.Entities.UI.Menu
{
  public class ExitButton : Entity, IMenuElement
  {
    private ExitDrawer _exitDrawer => Drawer as ExitDrawer;
    public ExitButton()
    {
      Drawer = new ExitDrawer();

      Position = new Position
      {
        X = 15,
        Y = 2
      };
    }

    public bool GetSelected()
      => _exitDrawer.IsSelected;

    public void SetSelected(bool selected)
      => _exitDrawer.IsSelected = selected;
  }

  internal class ExitDrawer : IEntityDrawer
  {
    private readonly AsciiCode _asciiCode;

    internal bool IsSelected;


    public ExitDrawer()
      => _asciiCode = new AsciiCode();

    public string Code()
      => "EXIT ";

    public string Replace(string element)
      => _asciiCode
        .AddDrawing(element)
        .AddColor("E", "100", IsSelected ? "90" : "50")
        .AddColor("X", "100", IsSelected ? "90" : "50")
        .AddColor("I", "100", IsSelected ? "90" : "50")
        .AddColor("T", "100", IsSelected ? "90" : "50")
        .Build();
  }
}