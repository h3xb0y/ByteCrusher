using System.Collections.Generic;
using ByteCrusher.Entities;
using SnakeGame.Model;
using GameData = SnakeGame.Services.GameData;

namespace SnakeGame.Controllers
{
  public class SnakeMovementController : SceneController
  {
    private Snake _snake;
    
    protected override void OnInitialize()
    {
      _snake = SnakeGame.Instance.GameService<GameData>().Snake;
    }

    protected override void OnProcess(List<Entity> entities, int width, int height)
    {
      _snake.Move();
    }
  }
}