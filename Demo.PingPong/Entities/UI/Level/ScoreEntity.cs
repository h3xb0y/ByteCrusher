using ByteCrusher.Data;
using ByteCrusher.Entities;

namespace PingPong.Entities.UI.Level
{
  public class ScoreEntity : Entity
  {
    private readonly ScoreDrawer _drawer = new ScoreDrawer();

    public ScoreEntity()
      => Position = new Position{ X = 48, Y = 9};  
    
    public override IEntityDrawer Drawer()
      => _drawer;

    public void IncreaseScore(bool isEnemyScore)
      => _drawer.IncreaseScore(isEnemyScore);
  }

  internal class ScoreDrawer : IEntityDrawer
  {
    private int _playerScore;
    private int _enemyScore;
    
    public void IncreaseScore(bool isEnemyScore)
    {
      if (isEnemyScore)
        _enemyScore++;
      else
        _playerScore++;
    }

    public string Code()
      => $"{_playerScore} : {_enemyScore} ";

    public string Replace(string element)
      => element;
  }
}