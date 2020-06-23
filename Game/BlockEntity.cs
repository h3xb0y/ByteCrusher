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
      var builder = new AsciiCodeBuilder();

      const string code = "  ****  \n" +
                          "********\n" +
                          "  ***  ";

      return builder
        .WithCode(code)
        .Where("*", "0x000015")
        .Build();
    }
  }
}