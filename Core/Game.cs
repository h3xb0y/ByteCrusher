using System.Collections.Generic;
using System.Linq.Expressions;

namespace ByteCrusher.Core
{
  public class Game
  {
    private int _width;
    private int _height;

    private List<IScene> Scenes;
    
    public Game(int width, int height)
    {
      _width = width;
      _height = height;
    }

    public Game WithScene(IScene scene)
    {
      if(Scenes == null)
        Scenes = new List<IScene>();
      
      Scenes.Add(scene);
      
      return this;
    }

    public void Play()
      => Expression.Empty();
  }
}