using CommunityToolkit.Maui.Views;

namespace MoonAlphaMauiApps;

public partial class FailedMessage : Popup
{
	public FailedMessage()
	{
		InitializeComponent();
	}

    private void Button_Click(object sender, EventArgs e)
    {
		this.Close(true);
    }
}