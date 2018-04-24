namespace RCM.Domain.Core.Errors
{
    public class CommandError : Error
    {
        public CommandError(string description, string code) : base(description, code)
        {
        }
    }
}
