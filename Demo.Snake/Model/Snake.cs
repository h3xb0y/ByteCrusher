using System.Collections.Generic;
using System.Linq;
using ByteCrusher.Data;

namespace SnakeGame.Model
{
  public class Snake
  {
    private readonly List<SnakeBodyPart> _bodyParts;
    private readonly MovementDirection _direction;
    private readonly SnakeBodyPart _head;

    public Snake()
    {
      _bodyParts = new List<SnakeBodyPart>();
      _head = new SnakeBodyPart {Position = new Position {X = 10, Y = 10}};
      _bodyParts.Add(_head);
      _direction = MovementDirection.Left;
    }

    public bool Move()
    {
      if (!_head.CanMoveTo(_direction))
        return false;

      Position lastPosition = null;

      foreach (var bodyPart in _bodyParts)
      {
        if (lastPosition == null)
        {
          lastPosition = bodyPart.Position.Clone();
          bodyPart.MoveTo(_direction);
        }
        else
        {
          var _lastPosition = bodyPart.Position.Clone();
          bodyPart.MoveTo(lastPosition);
          lastPosition = _lastPosition;
        }
      }

      return true;
    }

    public bool Eat(Food food)
    {
      if (!_head.Position.Equals(food.Position))
        return false;

      _bodyParts.Add(new SnakeBodyPart {Position = food.Position.Clone()});
      return true;
    }
  }
}