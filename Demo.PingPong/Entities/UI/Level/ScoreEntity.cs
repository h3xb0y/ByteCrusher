using System;
using ByteCrusher.Data;
using ByteCrusher.Entities;

namespace PingPong.Entities.UI.Level
{
  public class ScoreEntity : Entity
  {
    public DateTime LastIncrease { get; private set; }
    public bool Visible;

    private readonly ScoreDrawer _drawer = new ScoreDrawer();

    public ScoreEntity()
      => Position = new Position {X = 48, Y = 9};

    public override IEntityDrawer Drawer()
      => Visible
        ? (IEntityDrawer) _drawer
        : new EmptyEntityDrawer();

    public void IncreaseScore(bool isEnemyScore)
    {
      LastIncrease = DateTime.Now;
      Visible = true;
      _drawer.IncreaseScore(isEnemyScore);
    }

    public Score Score() => _drawer.Score;
  }

  internal class ScoreDrawer : IEntityDrawer
  {
    private Score _score;

    public Score Score => _score;

    public void IncreaseScore(bool isEnemyScore)
    {
      if (isEnemyScore)
        _score.Enemy++;
      else
        _score.Player++;
    }

    public string Code()
      => _score.ToString();

    public string Replace(string element)
      => element;
  }

  public struct Score
  {
    public int Enemy;
    public int Player;

    public override string ToString()
      => $"{Player} : {Enemy} ";
  }
}