using System.Linq;

namespace ByteCrusher.Core.Layer
{
  public class Layer
  {
    private string[] _symbols;

    public Layer(int width, int height)
    {
      _symbols = new string[height];
      
      for (var i = 0; i < height; i++)
      for (var j = 0; j < width; j++)
        _symbols[i] += " ";
    }

    public void Apply(string drawing, Position position = null)
    {
      
    }

    public override string ToString()
      => _symbols.Aggregate("", (current, symbol) => current + symbol + "\n");
  }
}