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
        var builder = new StringBuilder(_symbols[position?.Y + i ?? i]);
        var pastedCount = 0;
        for (var ii = 0; ii < splitedDrawing[i].Length; ii++)
        {
          var replacedDrawing = drawer.Replace(splitedDrawing[i][ii]);
          builder.Insert(position?.X + ii + pastedCount ?? ii + pastedCount, replacedDrawing);
          pastedCount += replacedDrawing.Length - 1;
        }

        _symbols[position?.Y + i ?? i] = builder.ToString();
      }
    }

    public override string ToString()
      => _symbols.Aggregate(string.Empty, (current, symbol) => current + symbol + '\n');
  }
}