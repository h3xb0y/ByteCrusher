using ByteCrusher.Addition;
using ByteCrusher.Data;
using ByteCrusher.Entities;

namespace PingPong.Entities.Level
{
  public class BallEntity : Entity
  {
    private readonly IEntityDrawer _drawer;

    public BallEntity()
    {
      Position = new Position {X = 50, Y = 10};
      Drawer = new BallDrawer();
    }

    internal class BallDrawer : IEntityDrawer
    {
      private const string _code =
        "***";

      private readonly AsciiCode _asciiCode;

      public BallDrawer()
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
}