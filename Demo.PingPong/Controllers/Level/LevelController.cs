using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ByteCrusher.Entities;
using PingPong.Entities.Level;
using PingPong.Entities.UI.Level;

namespace PingPong.Controllers.Level
{
  public class LevelController : ISceneController
  {
    public void InitializeIfNeeded(Game game)
      => Expression.Empty();

    public void Process(IEnumerable<Entity> entities, int width, int height)
    {
      var enumerable = entities as Entity[] ?? entities.ToArray();

      var enemy = enumerable.OfType<EnemyEntity>().First();
      var player = enumerable.OfType<PlayerEntity>().First();
      var ball = enumerable.OfType<BallEntity>().First();
      var score = enumerable.OfType<ScoreEntity>().First();

      ProcessScoreboard(player, enemy, ball, score);
      
      ProcessPlayerPosition(player, height);

      if (ball.Position.X > width / 2)
        ProcessEnemyPosition(enemy, ball);
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