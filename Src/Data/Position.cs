using ByteCrusher.Addition.Interfaces;

namespace ByteCrusher.Data
{
  public class Position : ICloneable<Position>
  {
    public float X;
    public float Y;

    public Position Clone()
      => new Position {X = X, Y = Y};

    public override bool Equals(object obj)
    {
      return obj is Position position &&
             position.X == X &&
             position.Y == Y;
    }
  }
}