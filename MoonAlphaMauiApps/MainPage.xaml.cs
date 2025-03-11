using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
namespace MoonAlphaMauiApps
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        PrivateKeyPopup privateKeyPopup;
        InfoPopup infoPopup;


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

            Console.WriteLine("All RadioButtons in 'profitFlexLayout' are now enabled.");
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
    }

}
