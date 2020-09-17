using ByteCrusher.Entities;

namespace PingPong.Controllers.Level.Entities
{
  public class BallController : IEntityController
  {
    private Direction _direction;

    public void InitializeIfNeeded(Game game)
    {
    }

    public void Process(Scene scene, Entity entity)
    {
      var position = entity.Position;

      if (position.X >= 100 - 1)
      {
        _direction = _direction == Direction.RightBottom
          ? Direction.LeftBottom
          : Direction.LeftTop;
      }
      else if(position.X <= 1)
      {
        _direction = _direction == Direction.LeftBottom
          ? Direction.RightBottom
          : Direction.RightTop;
      }

      if (position.Y <= 1)
      {
        _direction = _direction == Direction.LeftTop
          ? Direction.LeftBottom
          : Direction.RightBottom;
      }

      if (position.Y >= 20 - 1)
      {
        _direction = _direction == Direction.LeftBottom
          ? Direction.LeftTop
          : Direction.RightTop;
      }
        
      switch (_direction)
      {
        case Direction.LeftTop:
          position.X -= 1;
          position.Y -= 1;
          break;
        case Direction.LeftBottom:
          position.X -= 1;
          position.Y += 1;
          break;
        case Direction.RightTop:
          position.X += 1;
          position.Y -= 1;
          break;
        case Direction.RightBottom:
          position.X += 1;
          position.Y += 1;
          break;
      }
    }

    internal enum Direction
    {
      LeftTop,
      LeftBottom,
      RightTop,
      RightBottom
    }
  }
}