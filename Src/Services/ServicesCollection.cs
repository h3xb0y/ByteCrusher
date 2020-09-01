using System.Collections;
using System.Collections.Generic;
using ByteCrusher.Src.Services.Collection;

namespace ByteCrusher.Src.Services
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