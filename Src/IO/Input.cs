using System;

namespace ByteCrusher.IO
{
  public static class Input
  {
    private static ConsoleKey _key;

    public static void Update()
      => _key = Console.KeyAvailable
        ? Console.ReadKey(true).Key
        : default;

    public static ConsoleKey GetKey()
      => _key;
  }
}