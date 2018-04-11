using RCM.Domain.Core.Errors;
using System.Collections.Generic;

namespace RCM.Domain.Core.Commands
{
    public class CommandResult
    {
        public bool Success
        {
            get
            {
                return _errors.Count == 0;
            }
        }

        private List<CommandError> _errors;
        public IReadOnlyList<CommandError> Errors
        {
            get
            {
                return _errors;
            }
        }

        public CommandResult()
        {
            _errors = new List<CommandError>();
        }

        public void AddError(CommandError error)
        {
            _errors.Add(error);
        }
    }
}