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
        if(clone[i] != '\n' && i != clone.Length - 1)
          continue;

        strings.Add(clone.Substring(lastIndex, i - lastIndex).Replace('\n', '\0'));
        lastIndex = i;
      }

      return strings.ToArray();
    }
  }
}