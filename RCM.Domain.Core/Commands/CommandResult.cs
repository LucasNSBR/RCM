using System;
using System.Collections.Generic;

namespace RCM.Domain.Core.Commands
{
    public class CommandResult 
    {
        public bool Success { get; private set; }
        public ICollection<Exception> Errors { get; private set; }

        public CommandResult(bool success = false)
        {
            Success = success;
        }
    }
}
