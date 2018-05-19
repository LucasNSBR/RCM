using FluentValidation;
using System.Globalization;

namespace RCM.Domain.Validators
{
    public class LocalizedAbstractValidator<T> : AbstractValidator<T>
    {
        public LocalizedAbstractValidator()
        {
            ValidatorOptions.LanguageManager.Enabled = true;
            ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
        }
    }
}
