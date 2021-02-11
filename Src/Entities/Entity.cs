using System;
using System.Collections.Generic;
using ByteCrusher.Data;

namespace ByteCrusher.Entities
{
  public abstract class Entity : IDisposable
  {
    public Position Position = new Position();
    public bool Enabled = true;

    private List<EntityController> _controllers;

    private IEntityDrawer _drawer;

    public IEntityDrawer? Drawer
    {
      get => Enabled ? _drawer : new EmptyEntityDrawer();
      protected set => _drawer = value;
    }

    public void Initialize(Game game)
    {
      _controllers?.ForEach(x => x.Initialize(game));
      OnInitialize(game);
    }

    internal void Process(Scene scene)
    {
      if (!Enabled)
        return;

      _controllers?.ForEach(c => c.Process(scene, this));
    }

    public Entity AddController(EntityController controller)
    {
      if (_controllers == null)
        _controllers = new List<EntityController>();

      _controllers.Add(controller);

      return this;
    }

    public void Dispose()
    {
      _controllers?.ForEach(x => x.Dispose());
      OnDispose();
    }
    
    //region APi
    
    protected virtual void OnDispose() {}
    
    protected virtual void OnInitialize(Game game) {}
    
    //endregion
  }
}