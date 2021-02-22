using System;
using System.Collections.Generic;
using ByteCrusher.Entities;
using SnakeGame.Controllers;
using SnakeGame.Controllers.Init;
using SnakeGame.Log;
using SnakeGame.Services;

namespace SnakeGame
{
  internal class SnakeGame
  {
    public static Game Instance { get; private set; }
    
    public static void Main()
    {
      Instance = new Game(new FileLogger())
        .AddScenes(Scenes())
        .AddService(new GameData())
        .SetWidthAndHeight(100, 20);

      Instance.Play();
    }
    
    public static void Stop()
      => Environment.Exit(0);

    private static IEnumerable<Scene> Scenes()
    {
      yield return new Scene()
        .InitController<InitSnakeController>()
        .Controller<InputController>()
        .Controller<SnakeMovementController>()
        .Controller<FoodController>();
    }
  }
}