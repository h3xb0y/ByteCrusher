using System;
using ByteCrusher.Entities;
using ByteCrusher.Modules.Implementations;

namespace PingPong.Controllers.Level.Entities
{
  public class PlayerController : IEntityController
  {
    private Input _input;
    
    public void InitializeIfNeeded(Game game)
      => _input = game.Module<Input>();

    public void Process(Scene scene, Entity entity)
    {
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