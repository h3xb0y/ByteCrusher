using System.Collections.Generic;
using System.Linq;
using ByteCrusher.Modules;
using ByteCrusher.Modules.Implementations;
using ByteCrusher.Services;
using ByteCrusher.Services.Collection;

namespace ByteCrusher.Entities
{
  public class Game
  {
    private readonly Kernel _kernel;
    private readonly List<IGameService> _services;
    private readonly GameSettings _settings;
    private readonly List<IKernelModule> _kernelModules;
    private readonly ILogger _logger;
    
    public ILogger Logger => _logger;

    public Game(ILogger logger = null)
    {
      _logger = logger;
      _settings = new GameSettings();
      _services = new List<IGameService>{new SceneService(), new SoundService()};
      _kernelModules = new List<IKernelModule> {new Time(), new Input()};
      _kernel = new Kernel(_settings, _kernelModules, _logger);
      
      InitializeCore();
    }

    private void InitializeCore()
    {
      if (_logger != null)
        System.AppDomain.CurrentDomain.UnhandledException += (o, e) => _logger.LogException(o, e);
    }

    private void Initialize()
    {
      _services.ForEach(x => x.Initialize(_settings));
      _settings.Scenes.ForEach(x => x.Initialize());
    }

    public Game SetWidthAndHeight(int width, int height)
    {
      _settings.Width = width;
      _settings.Height = height;

      return this;
    }

    public Game SleepInterval(int sleepInterval)
    {
      _settings.SleepInterval = sleepInterval;

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

    public Game AddKernelModule(IKernelModule module)
    {
      _kernelModules.Add(module);

      return this;
    }

    public T GameService<T>() where T : IGameService
      => _services.OfType<T>().FirstOrDefault();
    
    public T Module<T>() where T : IKernelModule
      => _kernelModules.OfType<T>().FirstOrDefault();

    public Scene Scene()
      => _settings.Scenes[_settings.SceneIndex];


    public void Play()
    {
      Initialize();

      _kernel.Start();
    }

    public void Restart()
    {
      _kernel.Restart();
    }
  }

  public class GameSettings
  {
    public readonly List<Scene> Scenes = new List<Scene>();
    public int SceneIndex;
    public int SleepInterval;

    public int Width;
    public int Height;
  }
}