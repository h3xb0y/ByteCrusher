using System;

namespace ByteCrusher.Core
{
  public class Input
  {
    public static ConsoleKey? GetKey()
    {
      if (!Console.KeyAvailable)
        return null;

      return Console.ReadKey().Key;
    }
  }
}