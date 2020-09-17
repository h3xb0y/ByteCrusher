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
      var enumerable = _entities as Entity[] ?? _entities.ToArray();
      ProcessPlayerPosition(enumerable.OfType<PlayerEntity>().First(), width);
      ProcessEnemyPosition(enumerable.OfType<EnemyEntity>().First(), enumerable.OfType<BallEntity>().First());
    }

    private static void ProcessPlayerPosition(Entity player, int width)
    {
      if (player.Position.X > width)
        player.Position.X = 0;

      if (player.Position.X < 0)
        player.Position.X = width;
    }

    private static void ProcessEnemyPosition(Entity enemy, Entity ball)
      => enemy.MoveTo(ball, 0.7f);
  }
}