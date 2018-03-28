using Microsoft.Extensions.Options;
using RCM.Domain.Emails;
using RCM.Domain.Services.Email;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Linq;
using System.Threading.Tasks;

namespace RCM.Infra.Services.Email
{
    public class EmailDispatcher : IEmailDispatcher
    {
        private readonly string _sendGridUser;
        private readonly string _sendGridKey;

        public EmailDispatcher(IOptions<EmailClientConfiguration> options)
        {
            _sendGridUser = options.Value.SendGridUser;
            _sendGridKey = options.Value.SendGridKey;
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
}