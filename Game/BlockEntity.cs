using ByteCrusher.Core;

namespace ByteCrusher
{
  public class BlockEntity : Entity
  {
    protected override IEntityDrawer Drawer()
      => new BlockDrawer();
  }

  public class BlockDrawer : IEntityDrawer
  {
    public string Drawing()
    {
      var code = new AsciiCode();

      const string drawing = "  ****  \n" +
                             "********\n" +
                             "  ***  ";

      return code
        .WithDrawing(drawing)
        .WhereColor("*", "0x000015")
        .Build();
    }
  }
}