using ByteCrusher.Data;
using ByteCrusher.UI;

namespace PingPong.Entities.UI.Menu
{
  public class PingPongText : Text
  {
    protected override void OnInitialize()
    {
      Position = new Position
      {
        X = 40,
        Y = 5
      };

      Value = "Demo.PingPong";
      Color = "100";
    }
  }
}