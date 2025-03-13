namespace MoonAlphaMauiApps;

public partial class SplashPage : ContentPage
{
    private string fullText = "Welcome to MoonAlpha Bot";
    public SplashPage()
    {
        InitializeComponent();
        ShowTextLetterByLetter();
    }
    private async void ShowTextLetterByLetter()
    {
        lblWelcomeText.Text = ""; // Start with empty text

        foreach (char letter in fullText)
        {
            lblWelcomeText.Text += letter; // Add one letter at a time
            await Task.Delay(200); // Delay between letters (200ms for smooth effect)
        }

        await Task.Delay(2000); // Pause for 2 seconds after full text appears
        Application.Current.MainPage = new MainPage(); // Navigate to MainPage
    }
}