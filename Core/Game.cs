using System.Collections.Generic;
using System.Linq.Expressions;

namespace ByteCrusher.Core
{
  public class Game
  {
    private int _width;
    private int _height;

    internal int _frameRate;

    internal List<IScene> _scenes;

    public Game(int width, int height)
    {
      _width = width;
      _height = height;
    }

    public void Play()
      => Expression.Empty();
  }

  public static class GameExtensions
  {
    public static Game WithScene(this Game game, IScene scene)
    {
      if (game._scenes == null)
        game._scenes = new List<IScene>();

      game._scenes.Add(scene);

      return game;
    }

    public static Game ByFrameRate(this Game game, int frameRate)
    {
      game._frameRate = frameRate;
      return game;
    }
  }
}