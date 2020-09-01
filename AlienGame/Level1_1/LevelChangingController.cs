using System.Collections.Generic;
using System.Linq;
using ByteCrusher.Core.Entities;
using ByteCrusher.Core.Services.Collection;

namespace ByteCrusher.Examples.Alien.Level1_1
{
  public class LevelChangingController : ISceneController
  {
    public void Process(IEnumerable<Entity>? _entities, int width, int height)
    {
      var alien = _entities?.FirstOrDefault(x => x is AlienEntity);

      if (alien == null)
        return;

      if (alien.Position.X < width && alien.Position.Y < height)
        return;

      var sceneService = AlienGame.Services().Get<SceneService>();

      if (sceneService.HasNextLevel())
        sceneService.LoadNextLevel();
      else
        AlienGame.Stop();
    }
  }
}