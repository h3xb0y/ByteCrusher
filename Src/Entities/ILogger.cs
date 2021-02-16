using System;

namespace ByteCrusher.Entities
{
  public interface ILogger
  {
    void LogInfo(string info);
    void LogError(string error);
    void LogException(object sender, UnhandledExceptionEventArgs e);
  }
}