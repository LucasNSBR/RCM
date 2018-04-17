namespace RCM.Domain.Core.Errors
{
    public class CommandError
    {
        public string Code { get; }
        public string Description { get; }

        public CommandError(string description, string code = "Erro")
        {
            Code = code;
            Description = description;
        }
    }
}
