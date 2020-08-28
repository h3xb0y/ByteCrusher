using System.Collections.Generic;

namespace ByteCrusher.Core.Addition
{
  public class AsciiCode
  {
    private readonly Dictionary<string, string> _colorsByPattern = new Dictionary<string, string>();
    private readonly Dictionary<string, string> _backgroundByPattern = new Dictionary<string, string>();
    private readonly List<string> _skippedPatterns = new List<string>();

    private string _drawing;

    public AsciiCode AddDrawing(string drawing)
    {
      _drawing = drawing;
      return this;
    }

    public AsciiCode AddColor(string pattern, string color, string backgroundColor, bool usePattern = true)
    {
      _colorsByPattern[pattern] = color;
      _backgroundByPattern[pattern] = backgroundColor;
      
      if(!usePattern)
        _skippedPatterns.Add(pattern);

      return this;
    }

    public string Build()
    {
      var newDrawing = " ";

      foreach (var colorByPattern in _backgroundByPattern)
      {
        var pattern = colorByPattern.Key;
        if(!_drawing.Contains(pattern))
          continue;

        var background = colorByPattern.Value;
        newDrawing = _drawing.Replace(pattern, "\x1b[48;5;" + background + "m");
      }
      
      foreach (var colorByPattern in _colorsByPattern)
      {
        var pattern = colorByPattern.Key;
        if (!_drawing.Contains(pattern))
          continue;

        var canSkip = _skippedPatterns.Contains(pattern);

        var color = colorByPattern.Value;
        var coloredPattern = _drawing.Replace(pattern, "\x1b[38;5;" + color + "m" + (canSkip ? " "  : pattern));
        
        newDrawing = newDrawing != " " 
          ? newDrawing + coloredPattern 
          : coloredPattern;
      }

      return newDrawing;
    }
  }
}