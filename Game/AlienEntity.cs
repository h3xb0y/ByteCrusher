using System.Collections.Generic;
using ByteCrusher.Core;

namespace ByteCrusher.Game
{
  public class AlienEntity : Entity
  {
    public AlienEntity()
    {
      Position = new Position
      {
        X = 15,
        Y = 2
      };
    }

    private AlienDrawer _drawer = new AlienDrawer();
    public override IEntityDrawer Drawer()
      => _drawer;
  }

  public class AlienDrawer : IEntityDrawer
  {
    private AlienAnimatedDrawing _animatedDrawing = new AlienAnimatedDrawing();

    public string Drawing()
      => new AsciiCode()
        .WithDrawing(_animatedDrawing.Drawing())
        .WhereColor("*", "100")
        .Build();

    public string Code()
      => _animatedDrawing.Drawing();

    public string Replace(char element)
      => new AsciiCode()
        .WithDrawing(element.ToString())
        .WhereColor("*", "50")
        .WhereColor("]", "70")
        .WhereColor("[", "70")
        .Build();
  }

  public class AlienAnimatedDrawing
  {
    private readonly Dictionary<int, string> _drawingByIndex = new Dictionary<int, string>
    {
      {
        1, "  ]**[  \n" +
           "]*****[\n" +
           "  ]**[ ["
      },
      {
        2, "  ]****[  \n" +
           "]******[\n" +
           "  ]**[  "
      },
      {
        3, "  ][ [\n" +
           "]*****[ \n" +
           "  ]**[  "
      }
    };

    private const int _framesCount = 3;
    
    private int _currentFrame = 1;

    public string Drawing()
    {
      if (_currentFrame == _framesCount)
        _currentFrame = 1;

      return _drawingByIndex[_currentFrame++];
    }
  }
}