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
      if (drawer == null)
        return;
      
      var splitedDrawing = drawer.Code().SplitNewLine();
        
      if(splitedDrawing.Length > _symbols.Length)
        throw new Exception("Drawing height cannot be larger than game height.");

      for (var i = 0; i < splitedDrawing.Length; i++)
      {
        var currentYPos = position?.Y + i ?? i;
        if (currentYPos >= _symbols.Length || currentYPos < 0)
          continue;
        
        var currentLine = _symbols[currentYPos];
        var builder = new StringBuilder(currentLine);
        var pastedCount = 0;
        var line = splitedDrawing[i];
        
        if(line.Length > builder.Length)
          throw new Exception("Drawing length cannot be larger than game width.");
        
        for (var ii = 0; ii < line.Length; ii++)
        {
          var replacedDrawing = drawer.Replace(splitedDrawing[i][ii]);
          var currentXPos = position?.X + ii + pastedCount ?? ii + pastedCount;
          if(currentXPos >= builder.Length || currentXPos < 0)
            continue;
          
          builder.Remove(currentXPos, 1);
          builder.Insert(currentXPos, replacedDrawing);
          
          pastedCount += replacedDrawing.Length - 1;
        }

        _symbols[position?.Y + i ?? i] = builder.ToString();
      }
    }

    public override string ToString()
      => _symbols.Aggregate(string.Empty, (current, symbol) => current + symbol + '\n');
  }
}