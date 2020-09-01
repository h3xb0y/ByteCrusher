using System;
using ByteCrusher.Src.Entities;
using ByteCrusher.Src.IO;

namespace AlienGame
{
  public class AlienController : IEntityController
  {
    public void Process(Scene scene, Entity entity)
    {
      switch (Input.GetKey())
      {
        case ConsoleKey.RightArrow:
          entity.Position.X += 1;
          break;
          
        case ConsoleKey.DownArrow:
          entity.Position.Y += 1;
          break;
          
        case ConsoleKey.LeftArrow:
          entity.Position.X -= 1;
          break;
          
        case ConsoleKey.UpArrow:
          entity.Position.Y -= 1;
          break;
      }
    }
  }
}