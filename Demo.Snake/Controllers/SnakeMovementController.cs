using System.Collections.Generic;
using ByteCrusher.Entities;
using SnakeGame.Services;
using GameData = SnakeGame.Services.GameData;

namespace SnakeGame.Controllers
{
  public class SnakeMovementController : SceneController
  {
    private GameData _data;
    
    protected override void OnInitialize()
    {
      _data = SnakeGame.Instance.GameService<GameData>();
    }

    protected override void OnProcess(List<Entity> entities, int width, int height)
    {
      if (_data.Snake.Move())
        return;

      _data.State = GameState.Dead;
    }
  }
}