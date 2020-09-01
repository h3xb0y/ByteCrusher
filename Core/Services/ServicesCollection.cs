using System.Collections;
using System.Collections.Generic;
using ByteCrusher.Core.Services.Collection;

namespace ByteCrusher.Core.Services
{
  public class ServicesCollection : IEnumerable<IGameService>
  {
    public IEnumerator<IGameService> GetEnumerator()
    {
      yield return new SceneService();
      yield return new SoundService();
    }

    IEnumerator IEnumerable.GetEnumerator()
      => GetEnumerator();
  }
}