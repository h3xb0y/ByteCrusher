namespace ByteCrusher.Core.Entities
{
  public interface ILogger
  {
    void LogInfo(string info);
    void LogError(string error);

    void LogDrawing(string drawing);
  }
}