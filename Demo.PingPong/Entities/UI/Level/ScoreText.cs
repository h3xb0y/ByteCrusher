using System;
using ByteCrusher.Data;
using ByteCrusher.UI;

namespace PingPong.Entities.UI.Level
{
  public class ScoreText : Text
  {
    public DateTime LastIncrease { get; private set; }
    
    private Score _score = default;

    protected override void OnInitialize()
    {
      Position = new Position {X = 48, Y = 9};
      Color = "0";
    }

    public void IncreaseScore(bool isEnemyScore)
    {
      Enabled = true;
      LastIncrease = DateTime.Now;
      _score.IncreaseScore(isEnemyScore);
      
      Value = _score.ToString();
    }

    public Score Score() => Enabled ? _score : default;
  }

  public struct Score
  {
    public int Enemy;
    public int Player;

    public void IncreaseScore(bool isEnemyScore)
    {
      if (isEnemyScore)
        Enemy++;
      else
        Player++;
    }

    public override string ToString()
      => $"{Player} : {Enemy} ";
  }
}