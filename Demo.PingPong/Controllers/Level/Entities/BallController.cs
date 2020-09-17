using ByteCrusher.Entities;
using ByteCrusher.Modules.Implementations;

namespace PingPong.Controllers.Level.Entities
{
  public class BallController : IEntityController
  {
    private Time _time;
    private Direction _direction;

    public void InitializeIfNeeded(Game game)
    {
      _time = game.Module<Time>();
    }

    public void Process(Scene scene, Entity entity)
    {
      switch (_direction)
      {
        case Direction.LeftTop:
          entity.Position.X -= _time.DeltaTime;
          entity.Position.Y -= _time.DeltaTime;
          break;
        case Direction.LeftBottom:
          entity.Position.X -= _time.DeltaTime;
          entity.Position.Y += _time.DeltaTime;
          break;
        case Direction.RightTop:
          entity.Position.X += _time.DeltaTime;
          entity.Position.Y -= _time.DeltaTime;
          break;
        case Direction.RightBottom:
          entity.Position.X += _time.DeltaTime;
          entity.Position.Y -= _time.DeltaTime;
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