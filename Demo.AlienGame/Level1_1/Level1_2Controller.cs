using System.Collections.Generic;
using System.Linq.Expressions;
using ByteCrusher.Entities;

namespace AlienGame.Level1_1
{
  public class Level1_2Controller : ISceneController
  {
    public void InitializeIfNeeded(Game game)
      => Expression.Empty();

    public void Process(List<Entity> _entities, int width, int height)
    {
    }
  }
}