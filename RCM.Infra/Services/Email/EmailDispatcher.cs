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

        public EmailDispatcher()
        {
            _sendGridKey = EmailDispatcherConstants.SendGridKey;
            _sendGridUser = EmailDispatcherConstants.SendGridUser;
        }

        public async Task SendEmailAsync(EmailTemplate template)
        {
            var message = new SendGridMessage();
            message.SetFrom(new EmailAddress("lucas.pereira.campos@hotmail.com", "RCM Email Service"));
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
