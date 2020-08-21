namespace ByteCrusher.Core.Entities
{
  public interface IEntityDrawer
  {
    string Code();
    string Replace(char element);
  }
}