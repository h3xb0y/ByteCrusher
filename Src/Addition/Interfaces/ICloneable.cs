namespace ByteCrusher.Addition.Interfaces
{
  public interface ICloneable<out T>
  {
    T Clone();
  }
}