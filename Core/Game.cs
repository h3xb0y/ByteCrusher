using System.Collections.Generic;

namespace ByteCrusher.Core
{
  public class Game
  {
    private readonly Kernel _kernel;

    public Game(int width, int height)
      => _kernel = new Kernel()
        .WithWidthAndHeight(width, height);

    public void Play()
      => _kernel.Play();

    public void AddScenes(IEnumerable<Scene> scenes)
    {
      foreach (var scene in scenes)
        _kernel.WithScene(scene);
    }
  }
}