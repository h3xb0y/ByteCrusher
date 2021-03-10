using System;
using System.Collections.Generic;

namespace ByteCrusher.Entities
{
  public abstract class InitializationSceneController : IDisposable
  {
    public void Initialize(List<Entity>? entities)
    {
      OnInitialize(entities);
    }
    
    public void Dispose()
    {
      OnDispose();
    }
    
    //region API

    protected virtual void OnInitialize(List<Entity>? entities)
    {
    }

    protected virtual void OnDispose()
    {
    }
    
    //endregion
  }
}