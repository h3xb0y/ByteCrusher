using System.Collections.Generic;

namespace ByteCrusher.Core
{
  public interface ISceneUI
  {
    IReadOnlyCollection<IUIElement> UiElements { get; }
  }
}