namespace ByteCrusher.Core
{
  public class AsciiCodeBuilder
  {
    private string _code;
    
    public AsciiCodeBuilder WithCode(string code)
    {
      _code = code;
      return this;
    }

    public AsciiCodeBuilder Where(string pattern, string color)
    {
      _code.Replace(pattern, "{0,-12} #{1:X6}", n, Color.FromName(n).ToArgb() & 0xFFFFFF)
      return this;
    }

    public string Build()
      => _code;
  }
}