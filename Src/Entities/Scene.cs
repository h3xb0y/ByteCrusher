using System.Collections.Generic;
using System.Linq;

namespace ByteCrusher.Entities
{
  public sealed class Scene
  {
    private List<Entity> _entities;
    private IEntityDrawer _drawer;
    private List<SceneController> _controllers;

    public Scene AddEntity(Entity entity)
    {
      if (_entities == null)
        _entities = new List<Entity>();

      _entities.Add(entity);

      return this;
    }

    public Scene AddBackground(IEntityDrawer drawer)
    {
      _drawer = drawer;
      return this;
    }

    public Scene AddController(SceneController controller)
    {
      if (_controllers == null)
        _controllers = new List<SceneController>();
      
      _controllers.Add(controller);
      return this;
    }

    public bool RemoveController<T>() where T : SceneController
    {
      if (_controllers == null)
        return false;

      var removeCandidates = _controllers.Where(x => x is T).ToArray();
      _controllers = _controllers.Except(removeCandidates).ToList();

      return removeCandidates.Length > 0;
    }

    public void Initialize(Game game)
    {
      _controllers?.ForEach(x => x.Initialize(game));
      _entities?.ForEach(x => x.Initialize(game));
    }

    public void Process(int sceneWidth, int sceneHeight)
    {
      _controllers?.ForEach(x => x.Process(_entities, sceneWidth, sceneHeight));
      _entities?.ForEach(x => x.Process(this));
    }

    public string Drawing(Kernel kernel)
    {
      var layer = new Layer.Layer(kernel._settings.Width, kernel._settings.Height);

      if (_drawer != null)
        layer.Apply(_drawer);

      // apply all entities drawing by layering
      foreach (var entity in _entities ?? Enumerable.Empty<Entity>())
        layer.Apply(entity.Drawer, entity.Position);

      return layer.ToString();
    }
  }
}