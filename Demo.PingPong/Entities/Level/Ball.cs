using ByteCrusher.Addition;
using ByteCrusher.Data;
using ByteCrusher.Entities;
using PingPong.Controllers.Level.Entities;

namespace PingPong.Entities.Level
{
  public class Ball : Entity<BallController>
  {
    protected override void OnInitialize()
    {
      Position = new Position {X = 50, Y = 10};
      Drawer = new BallDrawer();
    }

    internal class BallDrawer : IEntityDrawer
    {
      private const string _code =
        "**";

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