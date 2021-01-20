using System.Collections.Generic;
using System.Linq;
using ByteCrusher.Entities;
using PingPong.Entities.UI.Level;
using PingPong.Services;

namespace PingPong.Controllers.Level
{
  public class LevelStateController : ISceneController
  {
    private LevelStateService _levelState;

    public void InitializeIfNeeded(Game game)
    {
      _levelState = game.GameServices().Get<LevelStateService>();
    }

    public void Process(List<Entity> entities, int width, int height)
    {
      var entity = entities.OfType<ScoreEntity>().First();
      if (entity.Score().Enemy > 2)
        ChangeState(LevelState.Death, entities);
    }

    private void ChangeState(LevelState state, List<Entity> entities)
    {
      if (_levelState.State == state)
        return;

      _levelState.State = state;
    }
  }
}