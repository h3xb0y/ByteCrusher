using ByteCrusher.Data;
using ByteCrusher.UI;
using PingPong.Services;

namespace PingPong.Entities.UI.Level
{
  public class LevelStateEntity : Text
  {
    protected override void OnInitialize()
    {
      Position = new Position {X = 48, Y = 12};
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