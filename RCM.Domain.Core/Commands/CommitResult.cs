using System;
using System.Collections.Generic;

namespace RCM.Domain.Core.Commands
{
    public class CommitResult 
    {
        public bool Success { get; }

        private List<Exception> _errors;
        public IReadOnlyList<Exception> Errors
        {
            get
            {
                return _errors;
            }
        }


        public CommitResult(bool success = false)
        {
            Success = success;

            _errors = new List<Exception>();
        }

        public void AddError(Exception ex)
        {
            _errors.Add(ex);
        }
    }
}
