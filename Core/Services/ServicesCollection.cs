using System.Collections;
using System.Collections.Generic;

namespace ByteCrusher.Core.Services
{
  public class ServicesCollection : IEnumerable<IGameService>
  {
    public IEnumerator<IGameService> GetEnumerator()
    {
      yield return new SceneService();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
  
  public class SceneService : IGameService
  {
    public void Initialize()
    {
      
    }

    public void Process()
    {
      
    }
  }
}