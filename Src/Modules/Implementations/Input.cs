using System;

namespace ByteCrusher.Modules.Implementations
{
  public class Input : IKernelModule
  {
    private ConsoleKey _key;

    public ConsoleKey GetKey()
      => _key;

    public void Update()
      => _key = Console.KeyAvailable
        ? Console.ReadKey(true).Key
        : default;
  }
}