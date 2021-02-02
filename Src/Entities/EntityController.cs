using System;

namespace ByteCrusher.Entities
{
  public abstract class EntityController : IDisposable
  {
    public void Initialize(Game game)
    {
      OnInitialize(game);
    }

    public void Process(Scene scene, Entity entity)
    {
      OnProcess(scene, entity);
    }

    public void Dispose()
    {
      OnDispose();
    }

    //region API
    protected virtual void OnDispose()
    {
    }

    protected virtual void OnInitialize(Game game)
    {
    }

    protected virtual void OnProcess(Scene scene, Entity entity)
    {
    }

    //endregion
  }
}