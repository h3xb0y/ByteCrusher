using System.Linq.Expressions;
using ByteCrusher.Entities;

namespace PingPong.Controllers.Level.Entities
{
  public class BallController : IEntityController
  {
    private const float MovespeedKoef = 1f;
    
    private Direction _direction = Direction.RightTop;

    public void InitializeIfNeeded(Game game)
      => Expression.Empty();

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
          position.X -= 1 * MovespeedKoef;
          position.Y -= 1 * MovespeedKoef;
          break;
        case Direction.LeftBottom:
          position.X -= 1 * MovespeedKoef;
          position.Y += 1 * MovespeedKoef;
          break;
        case Direction.RightTop:
          position.X += 1 * MovespeedKoef;
          position.Y -= 1 * MovespeedKoef;
          break;
        case Direction.RightBottom:
          position.X += 1 * MovespeedKoef;
          position.Y += 1 * MovespeedKoef;
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