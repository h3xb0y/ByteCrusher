using ByteCrusher.Entities;

namespace PingPong
{
  public static class U
  {
    public static void MoveTo(this Entity entity, Entity target, float step)
    {
      if (target.Position.Y > entity.Position.Y)
        entity.Position.Y += step;
      else if (target.Position.Y < entity.Position.Y)
        entity.Position.Y -= step;
    }
  }
}