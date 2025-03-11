namespace MoonAlphaMauiApps
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
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
    }

}
