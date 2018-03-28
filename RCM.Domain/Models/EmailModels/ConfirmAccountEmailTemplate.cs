using RCM.Domain.Emails;

namespace RCM.Domain.Models.EmailModels
{
    public class ConfirmAccountEmailTemplate : EmailTemplate
    {
        public string CallbackUrl { get; }

        public ConfirmAccountEmailTemplate(string to, string callbackUrl) : base(to)
        {
            CallbackUrl = callbackUrl;
        }
    }
}
