using System.Collections.Generic;

namespace ByteCrusher.Core
{
  public class Scene : IScene
  {
    private List<Entity> _entities;

    public IReadOnlyCollection<Entity> Entities()
      => _entities;

    public IScene WithEntity(Entity entity)
    {
      if(_entities == null)
        _entities = new List<Entity>();
      
      _entities.Add(entity);

      return this;
    }
  }
}