namespace ByteCrusher.Core
{
  public abstract class AsciiCodeBuilder
  {
    private string _code;
    
    public AsciiCodeBuilder WithCode(string code)
    {
      _code = code;
      return this;
    }

    public AsciiCodeBuilder Where(string pattern, string color)
    {
      // todo replace colors in pattern
      return this;
    }

    public string Build()
      => _code;
  }
}