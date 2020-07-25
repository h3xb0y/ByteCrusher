using System;
using ByteCrusher.Core;

namespace ByteCrusher.Game
{
  public class AlienController : IEntityController
  {
    private MovementDirection _direction;
    
    public void Process(Scene scene, Entity entity)
    {
      switch (_direction)
      {
        case MovementDirection.Right:
          entity.Position.X += 1;
          _direction = MovementDirection.Bottom;
          break;
        case MovementDirection.Bottom:
          entity.Position.Y -= 1;
          _direction = MovementDirection.Left;
          break;
        case MovementDirection.Left:
          entity.Position.X -= 1;
          _direction = MovementDirection.Top;
          break;
        case MovementDirection.Top:
          entity.Position.Y += 1;
          _direction = MovementDirection.Right;
          break;
        default:
          throw new ArgumentOutOfRangeException();
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