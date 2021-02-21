using ByteCrusher.Entities;
using Snake.Controllers.Entities;

namespace Snake.Entities
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