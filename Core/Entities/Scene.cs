using System.Collections.Generic;
using System.Linq;
using ByteCrusher.Core.Modules;

namespace ByteCrusher.Core.Entities
{
  public sealed class Scene
  {
    private List<Entity> _entities;
    private IEntityDrawer _drawer;
    private ISceneController _controller;

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

    public Scene AddController(ISceneController controller)
    {
      _controller = controller;
      return this;
    }

    public void Initialize()
    {
      // TODO
    }

    public void Process(int sceneWidth, int sceneHeight)
    {
      _controller?.Process(_entities, sceneWidth, sceneHeight);
      _entities?.ForEach(x => x.Process(this));
    }

    public string Drawing(Kernel kernel)
    {
      var layer = new Layer.Layer(kernel._settings.Width, kernel._settings.Height);

      if (_drawer != null)
        layer.Apply(_drawer);

      // apply all entities drawing by layering
      foreach (var entity in _entities ?? Enumerable.Empty<Entity>())
        layer.Apply(entity.Drawer(), entity.Position);

      return layer.ToString();
    }
  }
}