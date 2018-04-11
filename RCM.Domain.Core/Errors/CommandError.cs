namespace RCM.Domain.Core.Errors
{
    public class CommandError
    {
        private string errorMessage;

        public string Code { get; }
        public string Description { get; }

        public CommandError(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public CommandError(string errorMessage)
        {
            this.errorMessage = errorMessage;
        }
    }
}
