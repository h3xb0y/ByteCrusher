using System.Collections.Generic;

namespace ByteCrusher.Core
{
  public interface IScene
  {
    IReadOnlyCollection<Entity> Entities();
    IScene WithEntity(Entity entity);
  }
}