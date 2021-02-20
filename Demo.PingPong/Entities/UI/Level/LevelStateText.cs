using ByteCrusher.Data;
using ByteCrusher.UI;
using PingPong.Services;

namespace PingPong.Entities.UI.Level
{
  public class LevelStateText : Text
  {
    protected override void OnInitialize()
    {
      Position = new Position {X = 40, Y = 12};
      Color = "0";
      Enabled = false;
    }

    public void SetState(LevelState state)
    {
      if (!Enabled)
        Enabled = true;

      Value = state.ToUiString();
    }
  }
}