namespace Domain.ViewModels;

public class OptionsUserControlViewModel
{
    private bool _useAccountDisplayNames = true;

    /// <summary>
    ///     Use TDA account display names instead of numbers
    /// </summary>
    public bool UseAccountDisplayNames
    {
        get => _useAccountDisplayNames;
        set
        {
            Globals.UseAccountDisplayNames = value;
            _useAccountDisplayNames = value;
        }
    }
}