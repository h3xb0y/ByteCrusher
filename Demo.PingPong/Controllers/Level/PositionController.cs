using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ByteCrusher.Entities;
using PingPong.Entities.Level;
using PingPong.Services;

namespace PingPong.Controllers.Level
{
  public class PositionController : ISceneController
  {
    private LevelStateService _levelState;
    
    public void InitializeIfNeeded(Game game)
    {
      _levelState = game.GameServices().Get<LevelStateService>();
    }

    public void Process(List<Entity> entities, int width, int height)
    {
      if (_levelState.State == LevelState.Death)
        return;
      
      var enemy = entities.OfType<EnemyEntity>().First();
      var player = entities.OfType<PlayerEntity>().First();
      var ball = entities.OfType<BallEntity>().First();
      
      ProcessPlayerPosition(player, height);

      if (ball.Position.X > width / 2)
        ProcessEnemyPosition(enemy, ball);
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