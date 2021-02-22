using ByteCrusher.Entities;
using SnakeGame.Controllers.Entities;

namespace SnakeGame.Entities
{
  public class Snake : Entity<SnakeController>
  {
    protected override void OnDispose()
    {
    }

    protected override void OnInitialize()
    {
    }
  }
}