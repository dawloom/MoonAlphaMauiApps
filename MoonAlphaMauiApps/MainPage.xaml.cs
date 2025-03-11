using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
namespace MoonAlphaMauiApps
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        PrivateKeyPopup privateKeyPopup;
        InfoPopup infoPopup;
        private readonly string[] randomTexts = new[]
 {
    "[2025-02-06 12:05:23] [INFO] Bot initialized. Strategy: MoonSniper v2.4",
    "[2025-02-06 12:05:24] [INFO] Connecting to DEX API... Failed.",
    "[2025-02-06 12:05:25] [INFO] Fetching market data...",
    "[2025-02-06 12:06:12] [TRADE] Scanning trending pairs...",
    "[2025-02-06 12:06:15] [TRADE] Opportunity found: $DOGEPEPE - Volume Surge +340%",
    "[2025-02-06 12:06:16] [BUY] Executing market order: 2.5 BNB → 1,200,000,000 $DOGEPEPE",
    "[2025-02-06 12:06:17] [Failed] Buy Confirmed Failed.",
    "[2025-02-06 12:09:45] [INFO] $DOGEPEPE up 74% in 3 minutes.",
    "[2025-02-06 12:09:46] [SELL] Executing market order: 1,200,000,000 $DOGEPEPE → 4.3 BNB",
    "[2025-02-06 12:09:47] [Failed] Sell Confirmed. Profit: +1.8 BNB (+72%)",
    "[2025-02-06 12:12:32] [TRADE] Scanning for new entries...",
    "[2025-02-06 12:12:36] [TRADE] New Trend Alert: $MOONPUG -"
};

        public MainPage()
        {
            InitializeComponent();
             



        infoPopup = new InfoPopup();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ShowPrivateKeyPopup();

        }
        private void ShowPrivateKeyPopup()
        {
            privateKeyPopup = new PrivateKeyPopup();


            this.ShowPopup(privateKeyPopup);
        }
        private void ShowInfoPopup()
        {
            //this.ShowPopup(infoPopup);
        }
        public static void UpdateButtonText(MainPage page, string newText)
        {
            if (page == null)
            {
                System.Diagnostics.Debug.WriteLine("Page reference is null.");
                return;
            }

            Button targetButton = page.FindByName<Button>("btnConnect");
            
            if (targetButton != null)
            {
                targetButton.Text = newText;
                targetButton.IsEnabled = false;
                FlexLayout flex = page.FindByName<FlexLayout>("flexLayoutAmount");

                if (flex != null)
                {
                    // Loop through all children of the FlexLayout
                    foreach (var child in flex.Children)
                    {
                        if (child is RadioButton radioButton)
                        {
                            radioButton.IsEnabled = true;
                        }
                    }
                }

            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Button not found. Make sure the name is correct.");
            }
            }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void RadioButton_Checked(object sender, CheckedChangedEventArgs e)
        {
        }

        private void OnRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
        {

        }

        private void OnAmountChanged(object sender, CheckedChangedEventArgs e)
        {

        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtInputLink.Text))
            {
                var startBtn = (Button)FindByName("btnStart");

                if (startBtn == null)
                {

                    return;
                }
                startBtn.IsEnabled = true;

            }

            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ShowPrivateKeyPopup();
        }

        private void Button_Click_1(object sender, EventArgs e)
        {
            ShowInfoPopup();

        }

        private void sol1_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

        }

        private void amount_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (!e.Value) return; // Only proceed if checked

            var flex = (FlexLayout)FindByName("profitFlexLayout");

            if (flex == null)
            {
                
                return;
            }

            foreach (var child in flex.Children)
            {
                if (child is RadioButton radioButton)
                {
                    radioButton.IsEnabled = true;
                }
            }

            
        }

        private void profit_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (!e.Value) return; // Only proceed if checked

            var inputLink = (Entry)FindByName("txtInputLink");

            if (inputLink == null)
            {

                return;
            }
            inputLink.IsEnabled = true;

        }

        private void btnStart_Clicked(object sender, EventArgs e)
        {
            StartProgress();
        }
        private async void StartProgress()
        {
            double progress = 0;
            var startBtn = (Button)FindByName("btnStart");
            startBtn.IsEnabled = false;
            int index = 0; // Track text index

            while (progress < 1)
            {
                progress += 0.01; // Increase by 1%
                pbProgress.ProgressTo(progress, 1200, Easing.Linear);
                prgStatusLbl.Text = $"{(progress * 100):0}%";

                // Append text if within bounds
                if (index < randomTexts.Length)
                {
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        richtxtbox.Text += randomTexts[index] + Environment.NewLine;

                        // Scroll to the bottom
                        richtxtbox.CursorPosition = richtxtbox.Text.Length;
                    });
                    index++;
                }

                await Task.Delay(120); // Wait for 1.2 seconds per step
            }

            startBtn.IsEnabled = true;

        }


    }

}
