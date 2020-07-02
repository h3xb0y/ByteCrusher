using System.Collections.Generic;

namespace ByteCrusher.Core
{
  public abstract class Entity
  {
    public Position Position = new Position();
    
    private List<IEntityController> _controllers;

    public abstract IEntityDrawer Drawer();

    internal string Drawing(Scene scene)
      => Drawer().Drawing();

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