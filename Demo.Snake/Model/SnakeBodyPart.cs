using System;
using ByteCrusher.Data;

namespace SnakeGame.Model
{
  public class SnakeBodyPart
  {
    public Position Position;

    public bool CanMoveTo(MovementDirection direction)
    {
      switch (direction)
      {
        case MovementDirection.Left:
          return Position.X > 1;
        case MovementDirection.Right:
          return Position.X < 100; // todo 
        case MovementDirection.Top:
          return Position.Y > 0;
        case MovementDirection.Bottom:
          return Position.Y < 20;
        default:
          throw new ArgumentOutOfRangeException(nameof(direction), direction, "Unknown direction value");
      }
    }

    public void MoveTo(MovementDirection direction)
    {
      switch (direction)
      {
        case MovementDirection.Left:
          Position.X--;
          break;
        case MovementDirection.Right:
          Position.X++;
          return;
        case MovementDirection.Top:
          Position.Y++;
          break;
        case MovementDirection.Bottom:
          Position.Y--;
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof(direction), direction, "Unknown direction value");
      }
    }

    public void MoveTo(Position position)
    {
      Position.X = position.X;
      Position.Y = position.Y;
    }
  }
}