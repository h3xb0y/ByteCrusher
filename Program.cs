using ByteCrusher.Core;

namespace ByteCrusher
{
  internal class Program
  {
    public static void Main()
      => new Game(100, 100)
        .WithScene(new Scene()
          .WithEntity(new Entity())
          .WithEntity(new Entity())
        )
        .Play();
  }
}