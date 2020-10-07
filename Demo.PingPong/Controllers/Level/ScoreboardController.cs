using System;
using System.Collections.Generic;
using System.Linq;
using ByteCrusher.Entities;
using PingPong.Entities.Level;
using PingPong.Entities.UI.Level;

namespace PingPong.Controllers.Level
{
  public class ScoreboardController : ISceneController
  {
    private const int ScoreboardSecondsVisibility = 1;
    
    public void InitializeIfNeeded(Game game)
    {
      
    }

    public void Process(IEnumerable<Entity> _entities, int width, int height)
    {
      var enumerable = _entities as Entity[] ?? _entities.ToArray();
      
      var enemy = enumerable.OfType<EnemyEntity>().First();
      var player = enumerable.OfType<PlayerEntity>().First();
      var ball = enumerable.OfType<BallEntity>().First();
      var score = enumerable.OfType<ScoreEntity>().First();

      ProcessScoreboard(player, enemy, ball, score);
      ProcessScoreboardVisibility(score);
    }

    private static void ProcessScoreboardVisibility(ScoreEntity score)
    {
      if (DateTime.Now.Subtract(score.LastIncrease).Seconds >= ScoreboardSecondsVisibility)
        score.Visible = false;
    }

    private static void ProcessScoreboard(PlayerEntity player, EnemyEntity enemy, Entity ball, ScoreEntity score)
    {
      var ballX = (int)ball.Position.X;
      var playerX = (int)player.Position.X;
      var enemyX = (int)enemy.Position.X;
      
      var isOnPlayerField =  ballX == playerX;
      var isOnEnemyField = ballX == enemyX;

      if (isOnPlayerField)
      {
        var playerY = (int) player.Position.Y;
        var ballY = (int) ball.Position.Y;

        if (ballY < playerY || ballY > playerY + player.Height)
          score.IncreaseScore(true);
      }

      if (isOnEnemyField)
      {
        var enemyY = (int) enemy.Position.Y;
        var ballY = (int) ball.Position.Y;

        if (ballY < enemyY || ballY > enemyY + enemy.Height)
          score.IncreaseScore(false);
      }
    }
  }
}