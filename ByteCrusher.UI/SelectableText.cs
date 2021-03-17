namespace ByteCrusher.UI
{
  public class SelectableText : Text, ISelectable
  {
    private string _selectedColor;
    protected string SelectedColor
    {
      set => _selectedColor = value;
    }

    private string _selectedBackgroundColor;
    protected string SelectedBackgroundColor
    {
      set => _selectedBackgroundColor = value;
    }

    private string _color;
    protected new string Color
    {
      set => _color = value;
    }

    private string _backgroundColor;
    protected new string BackgroundColor
    {
      set => _backgroundColor = value;
    }

    private bool _isSelected;
    public bool GetSelected()
    {
      return _isSelected;
    }

    public void SetSelected(bool value)
    {
      _isSelected = value;
      base.Color = _isSelected && _selectedColor != null ? _selectedColor : _color;
      base.BackgroundColor = _isSelected && _selectedBackgroundColor != null ? _selectedBackgroundColor : _backgroundColor;
    }
  }
}