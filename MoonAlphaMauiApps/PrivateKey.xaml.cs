using CommunityToolkit.Maui.Views;

namespace MoonAlphaMauiApps;

public partial class PrivateKeyPopup : Popup
{
    public PrivateKeyPopup()
    {
        InitializeComponent();
    }

    private void OnCloseButtonClicked(object sender, EventArgs e)
    {
        Close();
    }

    private void OnOkButtonClicked(object sender, EventArgs e)
    {
        // Handle OK button logic here
        Close();
    }
}
