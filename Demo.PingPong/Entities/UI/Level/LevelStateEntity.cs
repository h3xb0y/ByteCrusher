using ByteCrusher.Data;
using ByteCrusher.Entities;
using PingPong.Services;

namespace PingPong.Entities.UI.Level
{
  public class LevelStateEntity : Entity
  {
    private LevelStateDrawer? _drawer => Drawer as LevelStateDrawer;

    public LevelStateEntity()
    {
      Position = new Position {X = 48, Y = 12};
      Drawer = new LevelStateDrawer();
      Enabled = false;
    }

    public void SetState(LevelState state)
    {
      if (!Enabled)
        Enabled = true;
      
      _drawer.SetState(state); 
    }
  }
  
  internal class LevelStateDrawer : IEntityDrawer
  {
    private LevelState _state;
    
    public void SetState(LevelState state)
      => _state = state;

    public string Code()
      => _state.ToUiString();

    public string Replace(string element)
      => element;
  }
}