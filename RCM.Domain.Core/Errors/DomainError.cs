namespace RCM.Domain.Core.Errors
{
    public class DomainError : Error
    {
        public DomainError(string description, string code = null) : base(description, code)
        {
        }
    }
}
