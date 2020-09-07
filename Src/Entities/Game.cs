using System.Collections.Generic;
using System.Linq;
using ByteCrusher.Modules;
using ByteCrusher.Modules.Implementations;
using ByteCrusher.Services;

namespace ByteCrusher.Entities
{
  public class Game
  {
    private readonly Kernel _kernel;
    private readonly GameServices _services;
    private readonly GameSettings _settings;
    private readonly List<IKernelModule> _kernelModules;

    public Game(ILogger logger = null)
    {
      _settings = new GameSettings();
      _services = new GameServices();
      _kernelModules = new List<IKernelModule> {new Time(), new Input()};
      _kernel = new Kernel(_settings, _kernelModules, logger);
    }

    private void Initialize()
    {
      _settings.Scenes.ForEach(x => x.Initialize(this));
      
      foreach (var service in new ServicesCollection())
      {
        service.Initialize(_settings);
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

    public Game AddKernelModule(IKernelModule module)
    {
      _kernelModules.Add(module);

      return this;
    }

    public GameServices GameServices()
      => _services;

    public T Module<T>() where T : IKernelModule
      => _kernelModules.OfType<T>().FirstOrDefault();


    public void Play()
    {
      Initialize();

      _kernel.Start();
    }
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