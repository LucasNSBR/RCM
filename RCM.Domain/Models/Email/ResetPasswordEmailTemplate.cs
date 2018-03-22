using RCM.Domain.Emails;

namespace RCM.Domain.Models.Email
{
    public class ResetPasswordEmailTemplate : EmailTemplate
    {
        public string CallbackUrl { get; }

        public ResetPasswordEmailTemplate(string to, string callbackUrl) : base(to)
        {
            CallbackUrl = callbackUrl;
        }
    }
}
