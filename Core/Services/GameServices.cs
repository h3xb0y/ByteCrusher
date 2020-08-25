using System;
using System.Collections.Generic;
using ByteCrusher.Core.Entities;

namespace ByteCrusher.Core.Services
{
  public class GameServices
  {
    private Dictionary<Type, IGameService> _services = new Dictionary<Type, IGameService>();
    
    public T Get<T>() where T : IGameService, new()
    {
      _services.TryGetValue(typeof(T), out var service);

      return (T) service;
    }

    public void Add(IGameService service)
    {
      _services[service.GetType()] = service;
    }
  }

  public interface IGameService
  {
    void Initialize(GameSettings settings);
  }
}