using ByteCrusher.Entities;

namespace ByteCrusher.Services.Collection
{
  public class SceneService : IGameService
  {
    private GameSettings _settings;
    public void Initialize(GameSettings settings)
      => _settings = settings;

    public void LoadNextLevel()
    {
      if (!HasNextLevel())
        return;
      
      _settings.SceneIndex++;
    }

    public bool HasNextLevel()
      => _settings.Scenes.Count > _settings.SceneIndex + 1;
  }
}