using RCM.Domain.Emails;
using System.Threading.Tasks;

namespace RCM.Domain.Services.Email
{
    public interface IEmailDispatcher
    {
        Task SendEmailAsync(EmailTemplate template);
    }
}
