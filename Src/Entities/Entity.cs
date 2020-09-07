using System.Collections.Generic;
using ByteCrusher.Data;

namespace ByteCrusher.Entities
{
  public abstract class Entity
  {
    public Position Position = new Position();

    public void Initialize(Game game)
      => _controllers?.ForEach(x => x.InitializeIfNeeded(game));
    
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