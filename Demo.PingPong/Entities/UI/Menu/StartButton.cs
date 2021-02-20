using ByteCrusher.UI;

namespace PingPong.Entities.UI.Menu
{
  public class StartButton : SelectableText
  {
    protected override void OnInitialize()
    {
      Value = "Start";
      Color = "100";
      BackgroundColor = "50";
      SelectedBackgroundColor = "90";
      
      SetSelected(true);
    }
  }
}