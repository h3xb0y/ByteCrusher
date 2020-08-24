using System.Collections.Generic;
using ByteCrusher.Core.Modules;
using ByteCrusher.Core.Services;

namespace ByteCrusher.Core.Entities
{
  public class Game
  {
    private readonly Kernel _kernel;
    private readonly GameServices _services;

    public Game(ILogger logger = null)
    {
      _kernel = new Kernel(logger);
      _services = new GameServices();

      foreach (var service in new ServicesCollection())
        _services.Add(service);
    }

    public Game WithWidthAndHeight(int width, int height)
    {
      _kernel._width = width;
      _kernel._height = height;

      return this;
    }

    public Game WithScenes(IEnumerable<Scene> scenes)
    {
      foreach (var scene in scenes)
        _kernel.WithScene(scene);

      return this;
    }

    public Game WithService(IGameService service)
    {
      _services.Add(service);
      
      return this;
    }


    public GameServices GameServices()
      => _services;

    public void Play()
      => _kernel.Play();
  }
}