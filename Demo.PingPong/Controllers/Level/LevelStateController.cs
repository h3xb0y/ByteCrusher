using System.Collections.Generic;
using System.Linq;
using ByteCrusher.Entities;
using PingPong.Entities.Level;
using PingPong.Entities.UI.Level;

namespace PingPong.Controllers.Level
{
  public class LevelStateController : ISceneController
  {
    private LevelState _state = LevelState.Play;
    
    public void InitializeIfNeeded(Game game)
    {
    }

    public void Process(List<Entity> entities, int width, int height)
    {
      var entity = entities.OfType<ScoreEntity>().First();
      if (entity.Score().Enemy > 2)
        ChangeState(LevelState.Death, entities);
    }

    private void ChangeState(LevelState state, List<Entity> entities)
    {
      if (_state == state)
        return;
      
      _state = state;
      var player = entities.First(x => x is PlayerEntity);
      entities.Remove(player);
    }
  }

  enum LevelState
  {
    Play,
    Death
  }
}