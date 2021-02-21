using System;
using System.Collections.Generic;
using ByteCrusher.Entities;
using Snake.Controllers;
using Snake.Log;

namespace Snake
{
  internal class SnakeGame
  {
    public static Game Instance { get; private set; }
    
    public static void Main()
    {
      Instance = new Game(new FileLogger())
        .AddScenes(Scenes())
        .SetWidthAndHeight(100, 20);

      Instance.Play();
    }
    
    public static void Stop()
      => Environment.Exit(0);

    private static IEnumerable<Scene> Scenes()
    {
      yield return new Scene()
        .Entity<Entities.Snake>()
        .Controller<FoodSpawnController>();
    }
  }
}