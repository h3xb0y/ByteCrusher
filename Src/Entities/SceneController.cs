using System;
using System.Collections.Generic;

namespace ByteCrusher.Entities
{
  public abstract class SceneController : IDisposable
  {
    public void Initialize(Game game)
    {
      OnInitialize(game);
    }

    public void Process(List<Entity>? entities, int width, int height)
    {
      OnProcess(entities, width, height);
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

    protected virtual void OnProcess(List<Entity>? entities, int width, int height)
    {
    }

    //endregion
  }
}