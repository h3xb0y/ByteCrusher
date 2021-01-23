using System;
using ByteCrusher.Entities;
using PingPong.Services;

namespace PingPong
{
  public static class U
  {
    public static void MoveTo(this Entity entity, Entity target, float step)
    {
      if (target.Position.Y > entity.Position.Y)
        entity.Position.Y += step;
      else if (target.Position.Y < entity.Position.Y)
        entity.Position.Y -= step;
    }

    public static string ToUiString(this LevelState state)
    {
      switch (state)
      {
        case LevelState.Win:
          return "You win! Press `R` for restart";
        case LevelState.Death:
          return "You lose! Press `R` for restart";
        
        default:
          throw new ArgumentOutOfRangeException(nameof(state), state, null);
      }
    }
  }
}