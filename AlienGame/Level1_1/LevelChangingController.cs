using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ByteCrusher.Entities;
using ByteCrusher.Entities;
using ByteCrusher.Services.Collection;

namespace AlienGame.Level1_1
{
  public class LevelChangingController : ISceneController
  {
    public void InitializeIfNeeded(Game game)
      => Expression.Empty();

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