using ByteCrusher.Entities;

namespace SnakeGame.Entities
{
  public class SnakePartEntity : Entity
  {
    protected override void OnInitialize()
      => Drawer = new SnakePartDrawer();

    private class SnakePartDrawer : IEntityDrawer
    {
      public string Code()
        => "o";

      public string Replace(string element)
        => element;
    }
  }
}