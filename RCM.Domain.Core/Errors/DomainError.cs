namespace RCM.Domain.Core.Errors
{
    public class DomainError : Error
    {
        public DomainError(string description, string code) : base(description, code)
        {
        }
    }
}
