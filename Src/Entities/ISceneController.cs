using System.Collections.Generic;
using ByteCrusher.Entities;

namespace ByteCrusher.Entities
{
  public interface ISceneController
  {
    void Process(IEnumerable<Entity>? _entities, int width, int height);
  }
}