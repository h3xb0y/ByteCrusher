using ByteCrusher.Entities;

namespace SnakeGame.Entities
{
  public class FoodEntity : Entity
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