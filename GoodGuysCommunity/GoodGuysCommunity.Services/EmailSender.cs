using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using GoodGuysCommunity.Services.Interfaces;

namespace GoodGuysCommunity.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        private const string EmailAdress = "goodguyscommunity@gmail.com";
        private const string Password = "goodguyscommunitypassword";
        private const string Username = "goodguyscommunity";

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var toAddress = new MailAddress(email);
            var fromAddress = new MailAddress(EmailAdress, Username);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, Password),
                Timeout = 20000
            };

            using (var mailMessage = new MailMessage(fromAddress, toAddress))
            {
                mailMessage.Subject = subject;
                mailMessage.Body = message;
                await smtp.SendMailAsync(mailMessage);
            }
        }
    }

}
