using System.Collections.Generic;
using System.Linq;
using ByteCrusher.Entities;
using PingPong.Entities.UI.Level;

namespace PingPong.Controllers.Level
{
  public class LevelStateController : ISceneController
  {
    private LevelState _state;
    
    public void InitializeIfNeeded(Game game)
    {
    }

    public void Process(IEnumerable<Entity> _entities, int width, int height)
    {
      var entity = _entities.OfType<ScoreEntity>().First();
      if(entity.Score().EnemyScore > 5)
        PingPongGame.Stop();
    }
  }

  enum LevelState
  {
    Play,
    Death
  }
}