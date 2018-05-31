using RCM.Domain.Emails;
using RCM.Domain.Services.Email;
using RCM.Infra.Services.Constants;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Linq;
using System.Threading.Tasks;

namespace RCM.Infra.Services.Email
{
#pragma warning disable 414
    public class EmailDispatcher : IEmailDispatcher
    {
        private readonly string _sendGridUser;
        private readonly string _sendGridKey;

        private readonly string _senderAddress;
        private readonly string _senderName;


        public EmailDispatcher()
        {
            _sendGridKey = EmailDispatcherConstants.SendGridKey;
            _sendGridUser = EmailDispatcherConstants.SendGridUser;

            _senderAddress = EmailDispatcherConstants.SendGridFromEmail;
            _senderName = EmailDispatcherConstants.SendGridFromName;

        }

        public async Task SendEmailAsync(EmailTemplate template)
        {
            var message = new SendGridMessage();
            
            message.SetFrom(new EmailAddress(_senderAddress, _senderName));
            message.AddTo(template.To);
            message.SetTemplateId(template.TemplateId);
            message.AddSubstitutions(template.SendGridSubstitutions.ToDictionary(k => k.Key, v => v.Value));

            await Execute(message);
        }

        private async Task Execute(SendGridMessage message)
        {
            var client = new SendGridClient(_sendGridKey);
            await client.SendEmailAsync(message);
        }
    }
#pragma warning restore 414
}
