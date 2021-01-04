using System;
using System.Collections.Generic;
using System.Linq;
using ByteCrusher.Entities;
using ByteCrusher.Modules.Implementations;
using ByteCrusher.Services.Collection;
using PingPong.Entities.UI.Menu;

namespace PingPong.Controllers.UI.Menu
{
  public class MainMenuController : ISceneController
  {
    private Input _input;

    public void InitializeIfNeeded(Game game)
      => _input = game.Module<Input>();

    public void Process(List<Entity> _entities, int width, int height)
    {
      var rightKeyPressed = _input?.PressedKey == ConsoleKey.RightArrow;
      var leftKeyPressed = _input?.PressedKey == ConsoleKey.LeftArrow;
      var enterPressed = _input?.PressedKey == ConsoleKey.Enter;

      var menuElements = _entities.OfType<IMenuElement>();

      var enumerable = menuElements as IMenuElement[] ?? menuElements.ToArray();

      if (enterPressed)
      {
        var selectedElement = enumerable.FirstOrDefault(x => x.GetSelected());

        switch (selectedElement)
        {
          case StartButton _:
            PingPongGame.Services().Get<SceneService>().LoadNextLevel();
            break;

          case ExitButton _:
            PingPongGame.Stop();
            break;
        }
      }

      if (!leftKeyPressed && !rightKeyPressed)
        return;

      foreach (var entity in enumerable)
      {
        entity.SetSelected(false);

        switch (entity)
        {
          case StartButton startButton:
            startButton.SetSelected(_input.PressedKey == ConsoleKey.LeftArrow);
            break;

          case ExitButton exitButton:
            exitButton.SetSelected(_input.PressedKey == ConsoleKey.RightArrow);
            break;
        }
      }
    }
  }
}