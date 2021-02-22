using ByteCrusher.Entities;
using SnakeGame.Controllers.Entities;

namespace SnakeGame.Entities
{
  public class SnakePartEntity : Entity
  {
    protected override void OnInitialize()
      => Drawer = new SnakePartDrawer();

    private class SnakePartDrawer : IEntityDrawer
    {
      public string Code()
        => "*";

      public string Replace(string element)
        => element;
    }
  }
}