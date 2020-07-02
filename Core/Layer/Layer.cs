using System;
using System.Linq;
using System.Text;

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

    public void Apply(IEntityDrawer drawer, Position position = null)
    {
      var splitedDrawing = drawer.Code().SplitNewLine();

      for (var i = 0; i < splitedDrawing.Length; i++)
      {
        var builder = new StringBuilder(_symbols[i]);
        for (var ii = 0; ii < splitedDrawing[i].Length; ii++)
          builder[ii] = Convert.ToChar(splitedDrawing[i][ii]);

        _symbols[i] = builder.ToString();
      }
    }

    public override string ToString()
      => _symbols.Aggregate("", (current, symbol) => current + symbol + "\n");
  }
}