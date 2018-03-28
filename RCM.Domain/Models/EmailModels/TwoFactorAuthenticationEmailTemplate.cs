using RCM.Domain.Emails;

namespace RCM.Domain.Models.EmailModels
{
    public class TwoFactorAuthenticationEmailTemplate : EmailTemplate
    {
        public string Code { get; }

        public TwoFactorAuthenticationEmailTemplate(string to, string code) : base(to)
        {
            Code = code;
        }
    }
}
