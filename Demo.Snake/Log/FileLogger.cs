using System;
using System.IO;
using ByteCrusher.Entities;

namespace Snake.Log
{
  public class FileLogger : ILogger
  {
    private const string _path = "log.txt";

    public FileLogger()
    {
      if (!File.Exists(_path))
        File.Create(_path);
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

    public void LogException(object sender, UnhandledExceptionEventArgs e)
    {
      using var stream = new StreamWriter(_path);
      stream.WriteLine($"Exception {e.ExceptionObject}");
    }
  }
}