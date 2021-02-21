using ByteCrusher.Entities;
using Snake.Controllers.Entities;

namespace Snake.Entities
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