using System;
using System.Collections.Generic;
using System.Linq;
using ByteCrusher.Entities;
using PingPong.Entities.Level;
using PingPong.Entities.UI.Level;
using PingPong.Services;

namespace PingPong.Controllers.Level
{
  public class ScoreboardController : SceneController
  {
    private const int ScoreboardSecondsVisibility = 1;
    private LevelStateService _levelState;
    
    protected override void OnInitialize()
    {
      _levelState = PingPongGame.Instance.GameServices().Get<LevelStateService>();
    }

    protected override void OnProcess(List<Entity> _entities, int width, int height)
    {
      if (_levelState.State != LevelState.Play)
        return;
      
      var enemy = _entities.OfType<EnemyEntity>().First();
      var player = _entities.OfType<PlayerEntity>().FirstOrDefault();
      if (player == null)
        return;
      
      var ball = _entities.OfType<BallEntity>().First();
      var score = _entities.OfType<ScoreEntity>().First();

      ProcessScoreboard(player, enemy, ball, score);
      ProcessScoreboardVisibility(score);
    }

    private static void ProcessScoreboardVisibility(ScoreEntity score)
    {
      if (DateTime.Now.Subtract(score.LastIncrease).Seconds >= ScoreboardSecondsVisibility)
        score.Enabled = false;
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