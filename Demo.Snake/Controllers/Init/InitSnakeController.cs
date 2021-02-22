using System.Collections.Generic;
using ByteCrusher.Entities;
using SnakeGame.Entities;
using SnakeGame.Services;

namespace SnakeGame.Controllers.Init
{
  public class InitSnakeController : InitializationSceneController
  {
    protected override void OnInitialize(List<Entity> entities)
    {
      var snake = SnakeGame.Instance.GameService<GameData>().Snake;

      var entity = new SnakePartEntity {Position = snake.Head.Position};
      
      entities.Add(entity);
    }
  }
}