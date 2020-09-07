namespace ByteCrusher.Entities
{
  public interface IEntityController
  {
    void InitializeIfNeeded(Game game);
    void Process(Scene scene, Entity entity);
  }
}