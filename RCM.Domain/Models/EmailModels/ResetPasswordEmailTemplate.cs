using RCM.Domain.Emails;

namespace RCM.Domain.Models.EmailModels
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
