using System.Collections.Generic;
using System.Linq;
using ByteCrusher.Core.Entities;
using ByteCrusher.Core.Services.Collection;

namespace ByteCrusher.Game.Level1_1
{
  public class FirstLevelController : ISceneController
  {
    public void Process(IEnumerable<Entity> _entities, int width, int height)
    {
      var alien = _entities.First(x => x is AlienEntity);

      if (alien.Position.X >= width || alien.Position.Y >= height)
        Program.Services().Get<SceneService>().LoadNext();
    }
  }
}