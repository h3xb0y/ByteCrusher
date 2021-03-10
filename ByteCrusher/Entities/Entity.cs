using System;
using ByteCrusher.Data;

namespace ByteCrusher.Entities
{
  public abstract class Entity : IDisposable
  {
    public Position Position = new Position();
    public bool Enabled = true;

    private IEntityDrawer _drawer;

    public IEntityDrawer? Drawer
    {
      get => Enabled ? _drawer : new EmptyEntityDrawer();
      protected set => _drawer = value;
    }

    public void Initialize()
    {
      _OnInitialize();
      OnInitialize();
    }

    public void Dispose()
    {
      _OnDispose();
      OnDispose();
    }

    //region APi

    protected virtual void OnDispose()
    {
    }

    protected virtual void OnInitialize()
    {
    }

    internal virtual void Process(Scene scene)
    {
    }

    internal virtual void _OnDispose()
    {
    }

    internal virtual void _OnInitialize()
    {
    }

    //endregion
  }

  public abstract class Entity<T> : Entity
    where T : EntityController, new()
  {
    private EntityController _controller;

    internal override void _OnInitialize()
    {
      _controller = new T();
      _controller.Initialize();
    }

    internal override void Process(Scene scene)
    {
      if (!Enabled)
        return;

      _controller.Process(scene, this);
    }

    internal override void _OnDispose()
    {
      _controller.Dispose();
      _controller = null;
    }
  }
}