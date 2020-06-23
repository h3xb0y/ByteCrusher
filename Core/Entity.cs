using System.Collections.Generic;

namespace ByteCrusher.Core
{
  public abstract class Entity
  {
    public Position Position;
    private List<IEntityController> _controllers;

    private IEntityDrawer _drawer;

    public Entity(IEntityDrawer drawer)
      => _drawer = drawer;

    internal void Initialize(Scene scene)
      => _drawer.Draw(scene);

    internal void Process(Scene scene)
      => _controllers?.ForEach(c => c.Process(scene, this));

    public Entity WithController(IEntityController controller)
    {
      if (_controllers == null)
        _controllers = new List<IEntityController>();

      _controllers.Add(controller);

      return this;
    }
  }
}