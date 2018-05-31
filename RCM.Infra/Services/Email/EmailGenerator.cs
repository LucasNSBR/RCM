using RCM.Domain.Emails;
using RCM.Domain.Models.EmailModels;
using RCM.Domain.Services.Email;
using RCM.Infra.Services.Constants;

namespace RCM.Infra.Services.Email
{
    public class EmailGenerator : IEmailGenerator
    {
        private readonly string _accountConfirmationTemplateId;
        private readonly string _resetPasswordTemplateId;
        private readonly string _twoFactorAuthTemplateId;

        public EmailGenerator()
        {
            _accountConfirmationTemplateId = EmailDispatcherConstants.SendGridAccountConfirmationEmailTemplateId;
            _resetPasswordTemplateId = EmailDispatcherConstants.SendGridPasswordResetEmailTemplateId;
            _twoFactorAuthTemplateId = EmailDispatcherConstants.SendGridTwoFactorAuthEmailTemplateId;
        }

        public EmailTemplate GenerateAccountConfirmationEmail(string to, string callbackUrl)
        {
            var emailTemplate = new ConfirmAccountEmailTemplate(to, callbackUrl);

            //SET SENDGRID TEMPLATE AND REPLACE SPECIFIED TERMS WITH VARIABLES IN EMAIL BODY
            emailTemplate.SetSendGridTemplateId(_accountConfirmationTemplateId);
            emailTemplate.AddSendGridSubstitutions("-to-", to);
            emailTemplate.AddSendGridSubstitutions("-code-", callbackUrl);

            return emailTemplate;
        }

        public EmailTemplate GeneratePasswordResetEmail(string to, string callbackUrl)
        {
            var emailTemplate = new ResetPasswordEmailTemplate(to, callbackUrl);

            emailTemplate.SetSendGridTemplateId(_resetPasswordTemplateId);
            emailTemplate.AddSendGridSubstitutions("-to-", to);
            emailTemplate.AddSendGridSubstitutions("-code-", callbackUrl);

            return emailTemplate;
        }

        public EmailTemplate GenerateTwoFactorAuthenticationEmail(string to, string code)
        {
            var emailTemplate = new ResetPasswordEmailTemplate(to, code);
            
            emailTemplate.SetSendGridTemplateId(_resetPasswordTemplateId);
            emailTemplate.AddSendGridSubstitutions("-to-", to);
            emailTemplate.AddSendGridSubstitutions("-code-", code);

            return emailTemplate;
        }
    }
}
