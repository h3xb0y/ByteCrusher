using System.Collections.Generic;
using ByteCrusher.Data;

namespace ByteCrusher.Entities
{
  public abstract class Entity
  {
    public Position Position = new Position();
    public bool Enabled = true;

    private List<IEntityController> _controllers;

    private IEntityDrawer _drawer;

    public IEntityDrawer? Drawer
    {
      get => Enabled ? _drawer : new EmptyEntityDrawer();
      set => _drawer = value;
    }

    public void Initialize(Game game)
      => _controllers?.ForEach(x => x.InitializeIfNeeded(game));

    internal void Process(Scene scene)
    {
      if (!Enabled)
        return;

      _controllers?.ForEach(c => c.Process(scene, this));
    }

    public Entity AddController(IEntityController controller)
    {
      if (_controllers == null)
        _controllers = new List<IEntityController>();

      _controllers.Add(controller);

      return this;
    }
  }
}