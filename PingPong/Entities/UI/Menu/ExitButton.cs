using ByteCrusher.Entities;

namespace PingPong.Entities.UI.Menu
{
  public class ExitButton : Entity
  {
    private bool _isSelected;

    public bool IsSelected
    {
      set => _isSelected = value;
    }
    
    public override IEntityDrawer Drawer()
    {
      throw new System.NotImplementedException();
    }
  }
}