using System;
using System.Collections.Generic;
using System.Linq;
using ByteCrusher.Data;
using ByteCrusher.Entities;
using SnakeGame.Entities;
using SnakeGame.Model;
using SnakeGame.Services;
using GameData = SnakeGame.Services.GameData;

namespace SnakeGame.Controllers
{
  public class FoodController : SceneController
  {
    private Snake _snake;
    private Food _food;

    private int _width;
    private int _height;

    protected override void OnInitialize()
    {
      var gameDataService = SnakeGame.Instance.GameService<GameData>();

      _snake = gameDataService.Snake;
      _width = gameDataService.AreaWidth;
      _height = gameDataService.AreaHeight;
    }

    protected override void OnProcess(List<Entity> entities, int width, int height)
    {
      if (_food == null)
      {
        _food = new Food();

        _food.Position = new Position();
        _food.Position.X = new Random().Next(0, _width);
        _food.Position.Y = new Random().Next(0, _height);

        var entity = new FoodEntity();
        entity.Position = _food.Position;
        entity.Initialize();

        entities.Add(entity);
      }
      else
      {
        var bodyPart = _snake.Eat(_food);
        if (bodyPart == null)
          return;

        _food = null;

        var foodEntity = entities.OfType<FoodEntity>().First();
        entities.Remove(foodEntity);

        var bodyPartEntity = new SnakePartEntity {Position = bodyPart.Position};
        bodyPartEntity.Initialize();
        entities.Add(bodyPartEntity);
      }
    }
  }
}