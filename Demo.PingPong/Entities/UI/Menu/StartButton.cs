using ByteCrusher.Data;
using ByteCrusher.UI;

namespace PingPong.Entities.UI.Menu
{
  public class StartButton : SelectableText
  {
    protected override void OnInitialize()
    {
      Position = new Position
      {
        X = 30,
        Y = 8
      };
      
      Value = "Start";
      Color = "100";
      BackgroundColor = "50";
      SelectedBackgroundColor = "90";
      
      SetSelected(true);
    }
  }
}