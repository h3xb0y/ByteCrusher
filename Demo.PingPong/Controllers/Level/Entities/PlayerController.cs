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
    
    protected override void OnInitialize(Game game)
    {
      _levelState = game.GameServices().Get<LevelStateService>();
      _input = game.Module<Input>();
    }

    protected override void OnProcess(Scene scene, Entity entity)
    {
      if (_levelState.State == LevelState.Death)
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