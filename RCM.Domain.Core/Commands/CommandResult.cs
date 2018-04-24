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

        private List<Error> _errors;
        public IReadOnlyList<Error> Errors
        {
            get
            {
                return _errors;
            }
        }

        public CommandResult()
        {
            _errors = new List<Error>();
        }

        public void AddError(Error error)
        {
            _errors.Add(error);
        }

        public void AddErrors(List<Error> errors)
        {
            _errors.AddRange(errors);
        }
    }
}