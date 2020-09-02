using System;
using ByteCrusher.Entities;
using ByteCrusher.IO;

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