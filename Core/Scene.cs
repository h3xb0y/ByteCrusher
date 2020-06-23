using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteCrusher.Core
{
  public sealed class Scene
  {
    private List<Entity> _entities;

    public Scene WithEntity(Entity entity)
    {
      if(_entities == null)
        _entities = new List<Entity>();
      
      _entities.Add(entity);

      return this;
    }

    public void Process()
      => _entities.ForEach(x => x.Process(this));

    public void Initialize()
    {
      var asciiCodes = _entities
        .Select(x => x.Drawing(this))
        .ToList();
      
      Console.Write(asciiCodes.First());
    }
    
  }
}