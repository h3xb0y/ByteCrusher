using ByteCrusher.Entities;
using ByteCrusher.Services;
using SnakeGame.Model;

namespace SnakeGame.Services
{
  public class GameData : IGameService
  {
    public Snake Snake;
    public int AreaWidth;
    public int AreaHeight;
    public GameState State;

    public void Initialize(GameSettings settings)
    {
      AreaWidth = settings.Width;
      AreaHeight = settings.Height;
      Snake = new Snake(AreaWidth, AreaHeight);
      State = GameState.Play;
    }
  }

  public enum GameState
  {
    Play,
    Dead
  }
}