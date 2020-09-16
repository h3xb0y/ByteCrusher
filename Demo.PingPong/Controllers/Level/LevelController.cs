using System.Collections.Generic;
using System.Linq;
using ByteCrusher.Entities;
using PingPong.Entities.Level;

namespace PingPong.Controllers.Level
{
  public class LevelController : ISceneController
  {
    public void InitializeIfNeeded(Game game)
    {
    }

    public void Process(IEnumerable<Entity> _entities, int width, int height)
    {
      ProcessPlayerPosition(_entities.OfType<PlayerEntity>().First(), width);
    }

    private static void ProcessPlayerPosition(Entity player, int width)
    {
      if (player.Position.X > width)
        player.Position.X = 0;
    }
  }
}