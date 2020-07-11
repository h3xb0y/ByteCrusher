namespace ByteCrusher.Core
{
  public interface IEntityDrawer
  {
    string Drawing();
    string Code();
    string Replace(char element);
  }
}