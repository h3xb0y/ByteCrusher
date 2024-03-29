using System.Collections.Generic;
using System.Linq;
using ByteCrusher.Entities;
using PingPong.Entities.Level;
using PingPong.Services;

namespace PingPong.Controllers.Level
{
  public class PositionController : SceneController
  {
    private LevelStateService _levelState;
    
    protected override void OnInitialize()
    {
      _levelState = PingPongGame.Instance.GameService<LevelStateService>();
    }

    protected override void OnProcess(List<Entity> entities, int width, int height)
    {
      if (_levelState.State != LevelState.Play)
        return;
      
      var enemy = entities.OfType<Enemy>().First();
      var player = entities.OfType<PlayerPlayer>().First();
      var ball = entities.OfType<Ball>().First();
      
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

    public void Dispose()
    {
    }
  }
}