using ByteCrusher.Data;
using ByteCrusher.Entities;
using PingPong.Drawer;

namespace PingPong.Entities.Level
{
  public class EnemyEntity : Entity
  {
    public int Height = 5;

    protected override void OnInitialize()
    {
      Drawer = new LevelEntityDrawer();
      Position = new Position {X = 98, Y = 10};
    }
  }
}