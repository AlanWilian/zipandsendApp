using System.Net;
using System.Net.Mail;
using zipandsendApp.Interfaces;

namespace zipandsendApp.Implementation
{
    public class SmtpOutput : IOutputHandler
    {
        private readonly string smtpOptions;

        public SmtpOutput(string smtpOptions)
        {
            this.smtpOptions = smtpOptions;
        }

        public void Send(string filePath)
        {
            var smtpHost = "";
            var smtpPort = 0;
            var smtpUsername = "";
            var smtpPassword = "";
            var enableSsl = true;
            var toAddress = "";


            using (var client = new SmtpClient(smtpHost, smtpPort))
            {
                client.EnableSsl = enableSsl;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

                using (var message = new MailMessage(smtpUsername, toAddress))
                {
                    message.Subject = "";
                    message.Body = "";
                    message.IsBodyHtml = true;

                    client.Send(message);
                }
            }
        }


    }
}
