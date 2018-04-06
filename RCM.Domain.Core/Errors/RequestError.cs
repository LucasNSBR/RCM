namespace RCM.Domain.Core.Errors
{
    public class RequestError
    {
        private string errorMessage;

        public string Code { get; }
        public string Description { get; }

        public RequestError(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public RequestError(string errorMessage)
        {
            this.errorMessage = errorMessage;
        }
    }
}
