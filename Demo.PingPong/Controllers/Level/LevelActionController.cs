using System;
using System.Collections.Generic;
using ByteCrusher.Entities;
using ByteCrusher.Modules.Implementations;

namespace PingPong.Controllers.Level
{
  public class LevelActionController : SceneController
  {
    private Input _input;
    private Game _game;
    protected override void OnInitialize(Game game)
    {
      _input = game.Module<Input>();
      _game = game;
    }

    protected override void OnProcess(List<Entity> entities, int width, int height)
    {
      if(_input.PressedKey == ConsoleKey.R)
        _game.Restart();
    }
  }
}