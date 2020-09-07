using System.Collections.Generic;

namespace ByteCrusher.Entities
{
  public interface ISceneController
  {
    void InitializeIfNeeded(Game game);
    void Process(IEnumerable<Entity>? _entities, int width, int height);
  }
}