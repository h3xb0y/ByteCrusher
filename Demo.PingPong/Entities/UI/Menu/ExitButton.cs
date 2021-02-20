using ByteCrusher.Data;
using ByteCrusher.UI;

namespace PingPong.Entities.UI.Menu
{
  public class ExitButton : SelectableText
  {
    protected override void OnInitialize()
    {
      Position = new Position
      {
        X = 15,
        Y = 2
      };

      Value = "Exit";
      Color = "100";
      BackgroundColor = "50";
      SelectedBackgroundColor = "90";
      
      SetSelected(false);
    }
  }
}