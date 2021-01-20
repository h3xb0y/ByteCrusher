using ByteCrusher.Data;
using ByteCrusher.Entities;
using PingPong.Drawer;

namespace PingPong.Entities.Level
{
  public class PlayerEntity : Entity
  {
    public int Height = 5;
    
    public PlayerEntity()
    {
      Drawer = new LevelEntityDrawer();
      Position = new Position {X = 0, Y = 10};
    }
  }
}