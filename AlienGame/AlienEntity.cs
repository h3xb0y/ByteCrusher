using ByteCrusher.Src.Addition;
using ByteCrusher.Src.Data;
using ByteCrusher.Src.Entities;

namespace AlienGame
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
    private readonly AsciiCode _asciiCode;
    public AlienDrawer()
    {
      _asciiCode = new AsciiCode()
        .AddColor("*", "150", "90")
        .AddColor("]", "200", "90")
        .AddColor("[", "200", "90");
    }
    
    public string Code()
      => " ]**[ \n" +
         "]****[\n" +
         " ]**[ ";

    public string Replace(string element)
      => _asciiCode
        .AddDrawing(element)
        .Build();
  }
}