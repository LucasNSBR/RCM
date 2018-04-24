namespace RCM.Domain.Core.Errors
{
    public abstract class Error
    {
        public string Code { get; }
        public string Description { get; }

        public Error(string description, string code = "Erro")
        {
            Code = code;
            Description = description;
        }
    }
}
