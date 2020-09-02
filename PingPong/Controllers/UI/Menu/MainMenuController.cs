using System;
using System.Collections.Generic;
using ByteCrusher.Entities;
using ByteCrusher.IO;
using PingPong.Entities.UI.Menu;

namespace PingPong.Controllers.UI.Menu
{
  public class MainMenuController : ISceneController
  {
    public void Process(IEnumerable<Entity> _entities, int width, int height)
    {
      foreach (var entity in _entities)
      {
        switch (entity)
        {
          case StartButton startButton:
            startButton.IsSelected = Input.GetKey() == ConsoleKey.LeftArrow;
            break;
          
          case ExitButton exitButton:
            exitButton.IsSelected = Input.GetKey() == ConsoleKey.RightArrow;
            break;
        }
      }
    }
  }
}