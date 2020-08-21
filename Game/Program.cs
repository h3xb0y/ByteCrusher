using System.Collections.Generic;
using System.IO;
using ByteCrusher.Core.Entities;

namespace ByteCrusher.Game
{
  internal static class Program
  {
    public static void Main()
    {
      new Core.Entities.Game(new FileLogger())
        .WithScenes(Scenes())
        .WithWidthAndHeight(100, 20)
        .Play();
    }

    private static IEnumerable<Scene> Scenes()
    {
      yield return new Scene()
        .WithEntity(
          new AlienEntity()
            .WithController(new AlienController())
        )
      .WithBackground(new BackgroundDrawer());
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