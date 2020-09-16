using ByteCrusher.Addition;
using ByteCrusher.Data;
using ByteCrusher.Entities;

namespace PingPong.Entities.Level
{
  public class PlayerEntity : Entity
  {
    private readonly PlayerDrawer _drawer;

    public PlayerEntity()
    {
      _drawer = new PlayerDrawer();
      Position = new Position {X = 50, Y = 19};
    }

    public override IEntityDrawer Drawer()
      => _drawer;
  }
  
  internal class PlayerDrawer : IEntityDrawer
  {
    private const string _code =
      "*************";
    
    private readonly AsciiCode _asciiCode;

    public PlayerDrawer()
      => _asciiCode = new AsciiCode();

    public string Code()
      => _code;

    public string Replace(string element)
      => _asciiCode
        .AddDrawing(element)
        .AddColor("*", "100", "0", true)
        .Build();
  }
}