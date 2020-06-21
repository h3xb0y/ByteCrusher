namespace ByteCrusher.Core
{
  public interface ILogger
  {
    void LogInfo(string info);
    void LogError(string error);
  }
}