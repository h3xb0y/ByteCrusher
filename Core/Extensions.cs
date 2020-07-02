using System.Collections.Generic;

namespace ByteCrusher.Core
{
  public static class Extensions
  {
    public static string[] SplitNewLine(this string @string)
    {
      var lastIndex = 0;
      var strings = new List<string>();
      var clone = (string) @string.Clone();
      
      for (var i = 0; i < clone.Length; i++)
      {
        if(clone[i] != '\n')
          continue;

        strings.Add(clone.Remove(lastIndex, i - lastIndex));
        lastIndex = i;
      }

      return strings.ToArray();
    }
  }
}