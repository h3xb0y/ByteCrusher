using ByteCrusher.Data;
using ByteCrusher.Entities;
using PingPong.Drawer;

namespace PingPong.Entities.Level
{
  public class EnemyEntity : Entity
  {
    private readonly LevelEntityDrawer _drawer;

    public EnemyEntity()
    {
      _drawer = new LevelEntityDrawer();
      Position = new Position {X = 50, Y = 0};
    }

    public override IEntityDrawer Drawer()
      => _drawer;
  }
}