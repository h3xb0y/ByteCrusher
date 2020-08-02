using ByteCrusher.Core;

namespace ByteCrusher.Game
{
  internal static class Program
  {
    public static void Main()
      => new Core.Game()
        .ByFrameRate(60)
        .WithScene(new Scene()
          .WithEntity(
            new AlienEntity()
              .WithController(new AlienController())
          )
          .WithBackground(new BackgroundDrawer())
        )
        .WithWidthAndHeight(100, 20)
        .Play();
  }
}