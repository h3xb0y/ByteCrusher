using System.Collections.Generic;

namespace ByteCrusher.Core
{
  public sealed class Scene
  {
    private List<Entity> _entities;
    private ISceneUI _ui;

    public List<Entity> Entities()
      => _entities;

    public Scene WithEntity(Entity entity)
    {
      if(_entities == null)
        _entities = new List<Entity>();
      
      _entities.Add(entity);

      return this;
    }

    public Scene WithUI(ISceneUI sceneUi)
    {
      _ui = sceneUi;

      return this;
    }

    public void Process()
      => _entities.ForEach(x => x.Process(this));

    public void Initialize()
      => _entities.ForEach(x => x.Initialize(this));
  }
}