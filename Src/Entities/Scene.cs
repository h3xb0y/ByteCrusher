using System.Collections.Generic;
using System.Linq;
using ByteCrusher.Entities;
using ByteCrusher.Modules;

namespace ByteCrusher.Entities
{
  public sealed class Scene
  {
    private List<Entity> _entities;
    private IEntityDrawer _drawer;
    private List<ISceneController> _controllers;

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
      if (_controllers == null)
        _controllers = new List<ISceneController>();
      
      _controllers.Add(controller);
      return this;
    }

    public void Initialize(Game game)
    {
      _controllers?.ForEach(x => x.InitializeIfNeeded(game));
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
        layer.Apply(entity.Drawer(), entity.Position);

      return layer.ToString();
    }
  }
}