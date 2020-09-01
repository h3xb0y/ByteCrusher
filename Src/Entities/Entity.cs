using System.Collections.Generic;
using ByteCrusher.Src.Data;

namespace ByteCrusher.Src.Entities
{
  public abstract class Entity
  {
    public Position Position = new Position();
    
    private List<IEntityController> _controllers;

    public abstract IEntityDrawer Drawer();

    internal void Process(Scene scene)
      => _controllers?.ForEach(c => c.Process(scene, this));

    public Entity AddController(IEntityController controller)
    {
      if (_controllers == null)
        _controllers = new List<IEntityController>();

      _controllers.Add(controller);

      return this;
    }
  }
}