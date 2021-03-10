using System.Collections.Generic;

namespace ByteCrusher
{
  public static class Extensions
  {
    public static string[] SplitNewLine(this string @string)
    {
      var lastIndex = 0;
      var strings = new List<string>();
      var clone = (string) @string.Clone();
      
      for (var i = 1; i <= clone.Length; i++)
      {
        if(clone[i - 1] != '\n' && i != clone.Length)
          continue;

        strings.Add(clone.Substring(lastIndex, i - lastIndex).Replace("\n", string.Empty));
        lastIndex = i;
      }

      return strings.ToArray();
    }
  }
}