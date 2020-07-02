using ByteCrusher.Core;

namespace ByteCrusher
{
  public class BlockEntity : Entity
  {
    public override IEntityDrawer Drawer()
      => new BlockDrawer();
  }

  public class BlockDrawer : IEntityDrawer
  {
    private const string _drawing = "  ****  \n" +
                                    "********\n" +
                                    "  ****  ";

    public string Drawing()
      => new AsciiCode()
        .WithDrawing(_drawing)
        .WhereColor("*", "100")
        .Build();

    public string Code()
      => _drawing;
  }
}