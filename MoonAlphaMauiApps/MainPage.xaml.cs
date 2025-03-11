using CommunityToolkit.Maui.Views;

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
            privateKeyPopup = new PrivateKeyPopup();
            infoPopup = new InfoPopup();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ShowPrivateKeyPopup();

        }
        private void ShowPrivateKeyPopup()
        {

           
            this.ShowPopup(privateKeyPopup);
        }
        private void ShowInfoPopup()
        {
            //this.ShowPopup(infoPopup);
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

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ShowPrivateKeyPopup();
        }

        private void Button_Click_1(object sender, EventArgs e)
        {
            ShowInfoPopup();

        }
    }

}
