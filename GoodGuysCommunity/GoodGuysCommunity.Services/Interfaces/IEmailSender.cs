using System.Threading.Tasks;

namespace GoodGuysCommunity.Services.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
