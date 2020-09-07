using System;
using ByteCrusher.Entities;
using ByteCrusher.Modules.Implementations;

namespace AlienGame
{
  public class AlienController : IEntityController
  {
    private Input _input;
    public void InitializeIfNeeded(Game game)
      => _input = game.Module<Input>();

    public void Process(Scene scene, Entity entity)
    {
      switch (_input.PressedKey)
      {
        case ConsoleKey.RightArrow:
          entity.Position.X += 1;
          break;
          
        case ConsoleKey.DownArrow:
          entity.Position.Y += 1;
          break;
          
        case ConsoleKey.LeftArrow:
          entity.Position.X -= 1;
          break;
          
        case ConsoleKey.UpArrow:
          entity.Position.Y -= 1;
          break;
      }
    }
  }
}