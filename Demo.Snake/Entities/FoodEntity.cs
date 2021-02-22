using ByteCrusher.Entities;
using SnakeGame.Controllers.Entities;

namespace SnakeGame.Entities
{
  public class FoodEntity : Entity<FoodController>
  {
    protected override void OnInitialize()
      => Drawer = new FoodDrawer();

    private class FoodDrawer : IEntityDrawer
    {
      public string Code()
        => "O";

      public string Replace(string element)
        => element;
    }
  }
}