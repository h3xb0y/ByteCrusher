using ByteCrusher.Core;

namespace ByteCrusher.Game
{
  internal static class Program
  {
    public static void Main()
      => new Core.Game()
        .ByFrameRate(30)
        .WithScene(new Scene()
          .WithEntity(new BlockEntity())
        )
        .WithWidthAndHeight(100, 20)
        .Play();
  }
}