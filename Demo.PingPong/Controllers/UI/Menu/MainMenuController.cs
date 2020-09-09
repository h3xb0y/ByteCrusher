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
    private Input _input;

    public void InitializeIfNeeded(Game game)
      => _input = game.Module<Input>();

    public void Process(IEnumerable<Entity> _entities, int width, int height)
    {
      var rightKeyPressed = _input?.PressedKey == ConsoleKey.RightArrow;
      var leftKeyPressed = _input?.PressedKey == ConsoleKey.LeftArrow;

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