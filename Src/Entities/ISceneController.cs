using System.Collections.Generic;

namespace ByteCrusher.Entities
{
  public interface ISceneController
  {
    void InitializeIfNeeded(Game game);
    void Process(List<Entity>? entities, int width, int height);
  }
}