using System;
using ByteCrusher.Entities;
using ByteCrusher.Modules.Implementations;
using PingPong.Services;

namespace PingPong.Controllers.Level.Entities
{
  public class PlayerController : EntityController
  {
    private Input _input;
    private LevelStateService _levelState;
    
    protected override void OnInitialize()
    {
      _levelState = PingPongGame.Instance.GameService<LevelStateService>();
      _input = PingPongGame.Instance.Module<Input>();
    }

    protected override void OnProcess(Scene scene, Entity entity)
    {
      if (_levelState.State != LevelState.Play)
        return;
      
      var key = _input.PressedKey;

      switch (key)
      {
        case ConsoleKey.UpArrow:
          entity.Position.Y -= 2;
          break;
        
        case ConsoleKey.DownArrow:
          entity.Position.Y += 2;
          break;
      }
    }
  }
}