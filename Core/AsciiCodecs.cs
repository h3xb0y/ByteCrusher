using System.Collections.Generic;

namespace ByteCrusher.Core
{
  public class AsciiCode
  {
    private Dictionary<string, string> _colorsByPattern = new Dictionary<string, string>();
    private Dictionary<string, string> _backgroundByPattern = new Dictionary<string, string>();

    private string _drawing;

    public AsciiCode WithDrawing(string drawing)
    {
      _drawing = drawing;
      return this;
    }

    public AsciiCode WhereColor(string pattern, string color)
    {
      _colorsByPattern[pattern] = color;
      return this;
    }

    public AsciiCode WhereColor(string pattern, string color, string backgroundColor)
    {
      _colorsByPattern[pattern] = color;
      _backgroundByPattern[pattern] = backgroundColor;

      return this;
    }

    public string Build()
    {
      var newDrawing = "";
      foreach (var colorByPattern in _colorsByPattern)
      {
        newDrawing = _drawing.Replace(colorByPattern.Key,
          "\x1b[38;5;" + colorByPattern.Value + "m" + colorByPattern.Key);
      }

      return newDrawing;
    }
  }
}