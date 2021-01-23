using ByteCrusher.Entities;
using ByteCrusher.Services;

namespace PingPong.Services
{
  public class LevelStateService: IGameService
  {
    public LevelState State;
    
    public void Initialize(GameSettings settings)
    {
    }
  }

  public enum LevelState
  {
    Play,
    Win,
    Death
  }
}