using ByteCrusher.Core.Addition;
using ByteCrusher.Core.Data;
using ByteCrusher.Core.Entities;

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
        .AddDrawing(element.ToString())
        .WhereColor("*", "150", "90")
        .WhereColor("]", "200", "90")
        .WhereColor("[", "200", "90")
        .Build();
  }
}