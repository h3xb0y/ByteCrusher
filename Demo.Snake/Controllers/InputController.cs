using System;
using System.Collections.Generic;
using ByteCrusher.Entities;
using ByteCrusher.Modules.Implementations;
using SnakeGame.Model;
using SnakeGame.Services;
using GameData = SnakeGame.Services.GameData;

namespace SnakeGame.Controllers
{
  public class InputController : SceneController
  {
    private Input _input;
    private Snake _snake;

    protected override void OnInitialize()
    {
      _input = SnakeGame.Instance.Module<Input>();
      _snake = SnakeGame.Instance.GameService<GameData>().Snake;
    }

    protected override void OnProcess(List<Entity> entities, int width, int height)
    {
      if (_input.PressedKey == ConsoleKey.LeftArrow && _snake.Direction != MovementDirection.Right)
        _snake.Direction = MovementDirection.Left;

      if (_input.PressedKey == ConsoleKey.RightArrow && _snake.Direction != MovementDirection.Left)
        _snake.Direction = MovementDirection.Right;

      if (_input.PressedKey == ConsoleKey.UpArrow && _snake.Direction != MovementDirection.Bottom)
        _snake.Direction = MovementDirection.Top;

      if (_input.PressedKey == ConsoleKey.DownArrow && _snake.Direction != MovementDirection.Bottom)
        _snake.Direction = MovementDirection.Bottom;
    }

    protected override void OnDispose()
    {
      _input = null;
      _snake = null;
    }
  }
}