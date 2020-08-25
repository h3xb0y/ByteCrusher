using ByteCrusher.Core.Entities;

namespace ByteCrusher.Core.Services.Collection
{
  public class SceneService : IGameService
  {
    private GameSettings _settings;
    public void Initialize(GameSettings settings)
    {
      _settings = settings;
    }

    public void LoadNextLevel()
    {
      _settings.SceneIndex++;
    }
  }
}