using System;
using System.Collections.Generic;
using ByteCrusher.Entities;
using ByteCrusher.Data;
using ByteCrusher.Entities;

namespace ByteCrusher.Layer
{
  public class Layer
  {
    private readonly Dictionary<int, string[]> _symbols;

    public Layer(int width, int height)
    {
      _symbols = new Dictionary<int, string[]>();

      for (var i = 0; i < height; i++)
      {
        _symbols[i] = new string[width];

        for (var ii = 0; ii < width; ii++)
          _symbols[i][ii] = " ";
      }
    }

    public void Apply(IEntityDrawer drawer, Position position = null)
    {
      if (drawer == null)
        return;

      var splitedDrawing = drawer.Code().SplitNewLine();

      if (splitedDrawing.Length > _symbols.Count)
        throw new Exception("Drawing height cannot be larger than game height.");

      for (var i = 0; i < splitedDrawing.Length; i++)
      {
        var currentYPos = position?.Y + i ?? i;
        if (currentYPos >= _symbols.Count || currentYPos < 0)
          continue;

        var currentLineArray = _symbols[(int) currentYPos];
        var line = splitedDrawing[i];

        if (line.Length > currentLineArray.Length)
          throw new Exception("Drawing length cannot be larger than game width.");

        for (var ii = 0; ii < line.Length; ii++)
        {
          var symbol = splitedDrawing[i][ii].ToString();
          var replacedDrawing = drawer.Replace(symbol);
          var currentXPos = position?.X + ii ?? ii;

          if (symbol == replacedDrawing && " " == replacedDrawing)
            continue;

          if (currentXPos >= currentLineArray.Length || currentXPos < 0)
            continue;

          currentLineArray[(int) currentXPos] = replacedDrawing;
        }
      }
    }

    public override string ToString()
    {
      var result = "";
      foreach (var keyValuePair in _symbols)
        result += string.Join("", keyValuePair.Value) + '\n';

      return result;
    }
  }
}