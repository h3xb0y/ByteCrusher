using System;

namespace ByteCrusher.Modules.Implementations
{
  public class Input : IKernelModule
  {
    public ConsoleKey PressedKey { get; private set; }

    public void Update()
      => PressedKey = Console.KeyAvailable
        ? Console.ReadKey(true).Key
        : default;
  }
}