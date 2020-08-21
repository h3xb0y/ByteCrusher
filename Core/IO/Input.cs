using System;

namespace ByteCrusher.Core.IO
{
  public static class Input
  {
    public static ConsoleKey? GetKey()
    {
      if (!Console.KeyAvailable)
        return null;

      return Console.ReadKey().Key;
    }
  }
}