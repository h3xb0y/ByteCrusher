using System;
using System.Collections.Generic;
using ByteCrusher.Entities;
using ByteCrusher.Modules.Implementations;

namespace PingPong.Controllers.Level
{
  public class LevelActionController : SceneController
  {
    private Input _input;
    
    protected override void OnInitialize()
      => _input = PingPongGame.Instance.Module<Input>();

    protected override void OnProcess(List<Entity> entities, int width, int height)
    {
      if(_input.PressedKey == ConsoleKey.R)
        PingPongGame.Instance.Restart();
    }
  }
}