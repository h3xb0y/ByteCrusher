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
      var splittedDrawing = drawer.Code().SplitNewLine();

      for (var i = 0; i < splittedDrawing.Length; i++)
      {
        var rowText = "";
        for (var ii = 0; ii < splittedDrawing[i].Length; ii++)
        {
          var replaceCandidate = splittedDrawing[i][ii];
          var replacedSymbol = drawer.Replace(replaceCandidate);
          rowText += replacedSymbol;
        }

        _symbols[position?.Y + i ?? i] = rowText;
      }
    }

    public override string ToString()
      => _symbols.Aggregate(string.Empty, (current, symbol) => current + symbol + '\n');
  }
}