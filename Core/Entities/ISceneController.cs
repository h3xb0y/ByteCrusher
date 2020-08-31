using System.Collections.Generic;

namespace ByteCrusher.Core.Entities
{
  public interface ISceneController
  {
    void Process(IEnumerable<Entity>? _entities, int width, int height);
  }
}