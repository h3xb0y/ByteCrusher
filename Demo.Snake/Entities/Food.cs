using ByteCrusher.Entities;
using SnakeGame.Controllers.Entities;

namespace SnakeGame.Entities
{
  public class Food : Entity<FoodController>
  {
    protected override void OnDispose()
    {
    }

    protected override void OnInitialize()
    {
    }
  }
}