using System.Collections;
using System.Collections.Generic;
using ByteCrusher.Core;

namespace ByteCrusher.Game
{
  internal class Program
  {
    private static Program _program;

    public static void Main()
    {
      var game = new Core.Game(100, 20);
      game.AddScenes(Scenes());
      game.Play();
    }

    private static IEnumerable<Scene> Scenes()
    {
      yield return new Scene()
        .WithEntity(
          new AlienEntity()
            .WithController(new AlienController())
        )
        .WithBackground(new BackgroundDrawer());
    }
  }
}