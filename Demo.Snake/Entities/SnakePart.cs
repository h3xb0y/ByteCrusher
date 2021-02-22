using ByteCrusher.Entities;
using SnakeGame.Controllers.Entities;

namespace SnakeGame.Entities
{
  public class SnakePart : Entity<SnakePartController>
  {
    protected override void OnDispose()
    {
    }

    protected override void OnInitialize()
    {
    }
  }
}