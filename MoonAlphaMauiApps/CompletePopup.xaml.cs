using CommunityToolkit.Maui.Views;

namespace MoonAlphaMauiApps;

public partial class CompletePopup : Popup
{
	public CompletePopup()
	{
		InitializeComponent();
	}

    private void Button_Click(object sender, EventArgs e)
    {
		this.Close();
    }
}