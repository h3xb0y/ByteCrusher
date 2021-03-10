using ByteCrusher.Addition;
using ByteCrusher.Entities;

namespace SnakeGame.Drawers
{
  public class BackgroundDrawer : IEntityDrawer
  {
    private readonly string _code;

    private readonly AsciiCode _asciiCode;

    public BackgroundDrawer()
    {
      _asciiCode = new AsciiCode();

      _code = "";

      for (var i = 0; i < 10; i++)
      for (var ii = 0; ii < 50; ii++)
        _code += ii == 49 ? "\n" : "_";
    }

    public string Code()
      => _code;

    public string Replace(string element)
      => _asciiCode
        .AddDrawing(element)
        .AddColor("_", "55", "10", true)
        .Build();
  }
}