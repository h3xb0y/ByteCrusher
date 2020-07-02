﻿using ByteCrusher.Core;

namespace ByteCrusher
{
  internal class Program
  {
    public static void Main()
      => new Game()
        .ByFrameRate(30)
        .WithScene(new Scene()
          .WithEntity(new BlockEntity())
        )
        .WithWidthAndHeight(100, 20)
        .Play();
  }
}