using ByteCrusher.Core;

namespace ByteCrusher.Game
{
  public class AlienController : IEntityController
  {
    private MovementDirection _direction;
    
    public void Process(Scene scene, Entity entity)
    {
      if (_direction == MovementDirection.Right)
      {
        entity.Position.X += 1;
        _direction = MovementDirection.Bottom;
      }
      else if (_direction == MovementDirection.Bottom)
      {
        entity.Position.Y -= 1;
        _direction = MovementDirection.Left;
      }
      else if (_direction == MovementDirection.Left)
      {
        entity.Position.X -= 1;
        _direction = MovementDirection.Top;
      }
      else if (_direction == MovementDirection.Top)
      {
        entity.Position.Y += 1;
        _direction = MovementDirection.Right;
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