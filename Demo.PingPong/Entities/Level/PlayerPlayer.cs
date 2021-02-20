using ByteCrusher.Data;
using ByteCrusher.Entities;
using PingPong.Controllers.Level.Entities;
using PingPong.Drawer;

namespace PingPong.Entities.Level
{
  public class PlayerPlayer : Entity<PlayerController>
  {
    public const int Height = 5;

    protected override void OnInitialize()
    {
      Drawer = new LevelEntityDrawer();
      Position = new Position {X = 0, Y = 10};
    }
  }
}