using System.Collections.Generic;
using ByteCrusher.Data;

namespace SnakeGame.Model
{
  public class Snake
  {
    public readonly List<SnakeBodyPart> BodyParts;
    public readonly SnakeBodyPart Head;

    public MovementDirection Direction;

    private int _areaWidth;
    private int _areaHeight;

    public Snake(int areaWidth, int areaHeight)
    {
      _areaWidth = areaWidth;
      _areaHeight = areaHeight;

      BodyParts = new List<SnakeBodyPart>();
      Head = new SnakeBodyPart(_areaWidth, _areaHeight) {Position = new Position {X = 10, Y = 10}};
      BodyParts.Add(Head);
      Direction = MovementDirection.Left;
    }

    public bool Move()
    {
      if (!Head.CanMoveTo(Direction))
        return false;

      Position lastPosition = null;

      foreach (var bodyPart in BodyParts)
      {
        if (lastPosition == null)
        {
          lastPosition = bodyPart.Position.Clone();
          bodyPart.MoveTo(Direction);
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

    public SnakeBodyPart Eat(Food food)
    {
      if (!Head.Position.Equals(food.Position))
        return null;

      var bodyPart = new SnakeBodyPart(_areaWidth, _areaHeight) {Position = food.Position.Clone()};
      BodyParts.Add(bodyPart);

      return bodyPart;
    }
  }
}