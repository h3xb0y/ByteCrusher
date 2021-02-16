using System.Collections.Generic;
using System.Linq;
using ByteCrusher.Entities;
using PingPong.Entities.UI.Level;
using PingPong.Services;

namespace PingPong.Controllers.Level
{
  public class LevelStateController : SceneController
  {
    private LevelStateService _levelState;

    protected override void OnInitialize()
    {
      _levelState = PingPongGame.Instance.GameServices().Get<LevelStateService>();
    }

    protected override void OnDispose()
    {
      _levelState.State = default;
    }

    protected override void OnProcess(List<Entity> entities, int width, int height)
    {
      var entity = entities.OfType<ScoreEntity>().First();
      var score = entity.Score();
      if (score.Enemy > 2)
        ChangeState(LevelState.Death, entities);
      else if(score.Player > 2)
        ChangeState(LevelState.Win, entities);
    }

    private void ChangeState(LevelState state, IEnumerable<Entity> entities)
    {
      if (_levelState.State == state)
        return;

      _levelState.State = state;
      
      entities.OfType<LevelStateEntity>().First().SetState(state);
    }
  }
}