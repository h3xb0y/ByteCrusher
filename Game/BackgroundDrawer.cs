using ByteCrusher.Core;

namespace ByteCrusher.Game
{
  public class BackgroundDrawer : IEntityDrawer
  {
    private const string _code =
      "****************************************************\n" +
      "*                                                  *\n" +
      "*                                                  *\n" +
      "*                                                  *\n" +
      "*                                                  *\n" +
      "*                                                  *\n" +
      "*                                                  *\n" +
      "*                                                  *\n" +
      "*                                                  *\n" +
      "****************************************************\n";

    public string Code()
      => _code;

    public string Replace(char element)
      => element.ToString();
  }
}