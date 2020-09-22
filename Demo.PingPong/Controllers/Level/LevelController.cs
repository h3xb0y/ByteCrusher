using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ByteCrusher.Entities;
using PingPong.Entities.Level;

namespace PingPong.Controllers.Level
{
  public class LevelController : ISceneController
  {
    public void InitializeIfNeeded(Game game)
      => Expression.Empty();

    public void Process(IEnumerable<Entity> _entities, int width, int height)
    {
      var enumerable = _entities as Entity[] ?? _entities.ToArray();
      ProcessPlayerPosition(enumerable.OfType<PlayerEntity>().First(), height);

      var ball = enumerable.OfType<BallEntity>().First();
      if (ball.Position.X > width / 2)
        ProcessEnemyPosition(enumerable.OfType<EnemyEntity>().First(), ball);
    }

    private static void ProcessPlayerPosition(Entity player, int height)
    {
      if (player.Position.Y > height)
        player.Position.Y = 0;

      if (player.Position.Y < 0)
        player.Position.Y = height;
    }

    private static void ProcessEnemyPosition(Entity enemy, Entity ball)
      => enemy.MoveTo(ball, 0.7f);
  }
}