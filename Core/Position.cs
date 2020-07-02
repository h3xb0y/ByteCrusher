namespace ByteCrusher.Core
{
  public class Position
  {
    public int X;
    public int Y;

    public int? PaddingLeft;
    public int? PaddingRight;
    public int? PaddingTop;
    public int? PaddingBottom;

    public bool PaddingOrientated =>
      PaddingLeft != null || PaddingRight != null || PaddingBottom != null || PaddingTop != null;
  }
}