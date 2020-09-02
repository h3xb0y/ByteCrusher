using System;

namespace ByteCrusher.IO
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