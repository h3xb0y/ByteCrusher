using System;
using ByteCrusher.Core;

namespace ByteCrusher.Game
{
  public class AlienController : IEntityController
  {
    private MovementDirection _direction;

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

    private enum MovementDirection
    {
      Right,
      Bottom,
      Left,
      Top
    }
  }
}