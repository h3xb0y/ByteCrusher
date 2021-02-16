using System;
using ByteCrusher.Data;
using ByteCrusher.Entities;

namespace PingPong.Entities.UI.Level
{
  public class ScoreEntity : Entity
  {
    public DateTime LastIncrease { get; private set; }

    private ScoreDrawer? _drawer => Drawer as ScoreDrawer;

    protected override void OnInitialize()
    {
      Position = new Position {X = 48, Y = 9};
      Drawer = new ScoreDrawer();
    }

    public void IncreaseScore(bool isEnemyScore)
    {
      Enabled = true;
      LastIncrease = DateTime.Now;
      _drawer?.IncreaseScore(isEnemyScore);
    }

    public Score Score() => Enabled ? _drawer.Score : default;
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