using System;
using System.Collections.Generic;
using System.IO;
using ByteCrusher.Entities;
using ByteCrusher.Services;
using PingPong.Controllers.Level;
using PingPong.Controllers.Level.Entities;
using PingPong.Controllers.UI.Menu;
using PingPong.Drawer;
using PingPong.Entities.Level;
using PingPong.Entities.UI.Menu;

namespace PingPong
{
  internal class PingPongGame : Game
  {
    private static Game _game;

    public static void Main()
    {
      _game = new Game(new FileLogger())
        .AddScenes(Scenes())
        .SetWidthAndHeight(100, 20);

      _game.Play();
    }

    public static void Stop()
      => Environment.Exit(0);

    public static GameServices Services()
      => _game.GameServices();

    private static IEnumerable<Scene> Scenes()
    {
      yield return new Scene()
        .AddEntity(new StartButton())
        .AddEntity(new ExitButton())
        .AddController(new MainMenuController())
        .AddBackground(new MenuBackgroundDrawer());

      yield return new Scene()
        .AddEntity(
          new PlayerEntity()
            .AddController(new PlayerController())
        )
        .AddEntity(
            new EnemyEntity()
          )
        .AddController(new LevelController())
        .AddBackground(new LevelBackgroundDrawer());
    }
  }

  public class FileLogger : ILogger
  {
    private const string _path = "log.txt";
    private const string _drawingPath = "drawing_logs.txt";

    public FileLogger()
    {
      if (!File.Exists(_path))
        File.Create(_path);

      if (!File.Exists(_drawingPath))
        File.Create(_drawingPath);
    }

    public void LogInfo(string info)
    {
      using var stream = new StreamWriter(_path);
      stream.WriteLine(info);
    }

    public void LogError(string error)
    {
      using var stream = new StreamWriter(_path);
      stream.WriteLine($"Error {error}");
    }

    public void LogDrawing(string drawing)
    {
      using var stream = new StreamWriter(_drawingPath);
      stream.WriteLine(_drawingPath);
    }
  }
}