namespace RCM.Domain.Core.Errors
{
    public class DomainError : Error
    {
        public DomainError(string code, string description) : base(description, code)
        {
        }
    }
}
