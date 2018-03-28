using RCM.Domain.Emails;
using RCM.Domain.Models.EmailModels;
using RCM.Domain.Services.Email;

namespace RCM.Infra.Services.Email
{
    public class EmailGenerator : IEmailGenerator
    {
        public EmailTemplate GenerateAccountConfirmationEmail(string to, string callbackUrl)
        {
            var emailTemplate = new ConfirmAccountEmailTemplate(to, callbackUrl);
            emailTemplate.SetSendGridTemplateId("e6b2144c-b3b0-40a2-931c-272201d6fc7a");
            emailTemplate.AddSendGridSubstitutions("-to-", to);
            emailTemplate.AddSendGridSubstitutions("-code-", callbackUrl);

            return emailTemplate;
        }

        public EmailTemplate GeneratePasswordResetEmail(string to, string callbackUrl)
        {
            var emailTemplate = new ResetPasswordEmailTemplate(to, callbackUrl);
            emailTemplate.SetSendGridTemplateId("aa74fc08-e40a-4889-9f05-d92d46704918");
            emailTemplate.AddSendGridSubstitutions("-to-", to);
            emailTemplate.AddSendGridSubstitutions("-code-", callbackUrl);

            return emailTemplate;
        }

        public EmailTemplate GenerateTwoFactorAuthenticationEmail(string to, string code)
        {
            var emailTemplate = new ResetPasswordEmailTemplate(to, code);
            emailTemplate.SetSendGridTemplateId("3ebb8487-45be-44f6-8525-bfcd4fb28b43");
            emailTemplate.AddSendGridSubstitutions("-to-", to);
            emailTemplate.AddSendGridSubstitutions("-code-", code);

            return emailTemplate;
        }
    }
}
