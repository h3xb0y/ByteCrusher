using ByteCrusher.Core;

namespace ByteCrusher.Game
{
  public class AlienEntity : Entity
  {
    private readonly AlienDrawer _drawer = new AlienDrawer();
    
    public AlienEntity()
    {
      Position = new Position
      {
        X = 15,
        Y = 2
      };
    }
    
    public override IEntityDrawer Drawer()
      => _drawer;
  }

  public class AlienDrawer : IEntityDrawer
  {
    public string Code()
      => " ]**[ \n" +
         "]****[\n" +
         " ]**[ ";

    public string Replace(char element)
      => new AsciiCode()
        .WithDrawing(element.ToString())
        .WhereColor("*", "150")
        .WhereColor("]", "200")
        .WhereColor("[", "200")
        .Build();
  }
}