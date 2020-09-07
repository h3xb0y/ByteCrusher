using System;
using System.Collections.Generic;
using System.Linq;
using ByteCrusher.Entities;
using ByteCrusher.Modules.Implementations;
using PingPong.Entities.UI.Menu;

namespace PingPong.Controllers.UI.Menu
{
  public class MainMenuController : ISceneController
  {
    public void Process(IEnumerable<Entity> _entities, int width, int height)
    {
      var rightKeyPressed = Input.GetKey() == ConsoleKey.RightArrow;
      var leftKeyPressed = Input.GetKey() == ConsoleKey.LeftArrow;

      if (!leftKeyPressed && !rightKeyPressed)
        return;
      
      foreach (var entity in _entities.OfType<IMenuElement>())
      {
        entity.SetSelected(false);
        
        switch (entity)
        {
          case StartButton startButton:
            startButton.SetSelected(leftKeyPressed);
            break;

          case ExitButton exitButton:
            exitButton.SetSelected(rightKeyPressed);
            break;
        }
      }
    }
  }
}