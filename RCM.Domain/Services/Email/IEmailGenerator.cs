using RCM.Domain.Emails;

namespace RCM.Domain.Services.Email
{
    public interface IEmailGenerator
    {
        EmailTemplate GenerateAccountConfirmationEmail(string to, string callbackUrl);
        EmailTemplate GeneratePasswordResetEmail(string to, string callbackUrl);
        EmailTemplate GenerateTwoFactorAuthenticationEmail(string to, string code);
    }
}
