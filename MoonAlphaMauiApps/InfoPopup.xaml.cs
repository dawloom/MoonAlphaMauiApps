using CommunityToolkit.Maui.Views;

namespace MoonAlphaMauiApps;

public partial class InfoPopup : Popup
{
	public InfoPopup()
	{
		InitializeComponent();
	}

    private void OnCloseButtonClicked(object sender, EventArgs e)
    {
		this.Close();
    }
}