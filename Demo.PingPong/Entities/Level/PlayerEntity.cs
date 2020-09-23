using ByteCrusher.Data;
using ByteCrusher.Entities;
using PingPong.Drawer;

namespace PingPong.Entities.Level
{
  public class PlayerEntity : Entity
  {
    public int Height = 5;
    
    private readonly LevelEntityDrawer _drawer;

    public PlayerEntity()
    {
      _drawer = new LevelEntityDrawer();
      Position = new Position {X = 0, Y = 10};
    }

    public override IEntityDrawer Drawer()
      => _drawer;
  }
}