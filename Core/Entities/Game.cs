using System.Collections.Generic;
using ByteCrusher.Core.Modules;
using ByteCrusher.Core.Services;

namespace ByteCrusher.Core.Entities
{
  public class Game
  {
    private readonly Kernel _kernel;
    private readonly GameServices _services;
    private readonly GameSettings _settings;

    public Game(ILogger logger = null)
    {
      _settings = new GameSettings();
      _services = new GameServices();
      _kernel = new Kernel(_settings, logger);

      Initialize();
    }

    private void Initialize()
    {
      foreach (var service in new ServicesCollection())
      {
        service.Initialize();
        _services.Add(service);
      }
    }

    public Game SetWidthAndHeight(int width, int height)
    {
      _settings.Width = width;
      _settings.Height = height;

      return this;
    }

    public Game AddScenes(IEnumerable<Scene> scenes)
    {
      foreach (var scene in scenes)
        _settings.Scenes.Add(scene);

      return this;
    }

    public Game AddService(IGameService service)
    {
      _services.Add(service);
      
      return this;
    }


    public GameServices GameServices()
      => _services;

    public void Play()
      => _kernel.Start();
  }

  public class GameSettings
  {
    public List<Scene> Scenes = new List<Scene>();
    public int SceneIndex;
    public int FrameRate;
    
    public int Width;
    public int Height;
  }
}