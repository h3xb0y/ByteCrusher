using ByteCrusher.Addition;
using ByteCrusher.Entities;

namespace PingPong.Drawer
{
  public class LevelEntityDrawer : IEntityDrawer
  {
    private const string _code =
      "*************";

    private readonly AsciiCode _asciiCode;

    public LevelEntityDrawer()
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