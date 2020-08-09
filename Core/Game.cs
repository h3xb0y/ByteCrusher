using System.Collections.Generic;

namespace ByteCrusher.Core
{
  public class Game
  {
    private readonly Kernel _kernel;

    public Game(ILogger logger = null)
    {
      _kernel = new Kernel(logger);
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

    public void Play()
      => _kernel.Play();
  }
}