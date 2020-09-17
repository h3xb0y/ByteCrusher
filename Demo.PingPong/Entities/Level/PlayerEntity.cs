using ByteCrusher.Data;
using ByteCrusher.Entities;
using PingPong.Drawer;

namespace PingPong.Entities.Level
{
  public class PlayerEntity : Entity
  {
    private readonly LevelEntityDrawer _drawer;

    public PlayerEntity()
    {
      _drawer = new LevelEntityDrawer();
      Position = new Position {X = 50, Y = 19};
    }

    public override IEntityDrawer Drawer()
      => _drawer;
  }
}