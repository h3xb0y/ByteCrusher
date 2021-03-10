namespace ByteCrusher.Entities
{
  public interface IEntityDrawer
  {
    string Code();
    string Replace(string element);
  }

  public class EmptyEntityDrawer : IEntityDrawer
  {
    public string Code()
      => string.Empty;

    public string Replace(string element)
      => element;
  }
}