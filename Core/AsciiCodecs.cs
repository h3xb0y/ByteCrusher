using System.Collections.Generic;

namespace ByteCrusher.Core
{
  public class AsciiCode
  {
    private Dictionary<string, string> _colorByPattern = new Dictionary<string, string>();
    private Dictionary<string, string> _backgroundByPattern = new Dictionary<string, string>();

    private string _drawing;

    public AsciiCode WithDrawing(string drawing)
    {
      _drawing = drawing;
      return this;
    }

    public AsciiCode WhereColor(string pattern, string color)
    {
      _colorByPattern[pattern] = color;
      return this;
    }

    public AsciiCode WhereColor(string pattern, string color, string backgroundColor)
    {
      _colorByPattern[pattern] = color;
      _backgroundByPattern[pattern] = backgroundColor;
      
      return this;
    }

    public string Build()
      => _drawing;
  }
}