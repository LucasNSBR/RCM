using RCM.Domain.Core.Errors;
using System.Collections.Generic;

namespace RCM.Domain.Core.Commands
{
    public class RequestResponse
    {
        public bool Success
        {
            get
            {
                return _errors.Count == 0;
            }
        }

        private List<RequestError> _errors;
        public IReadOnlyList<RequestError> Errors
        {
            get
            {
                return _errors;
            }
        }

        public RequestResponse()
        {
            _errors = new List<RequestError>();
        }

        public void AddError(RequestError error)
        {
            _errors.Add(error);
        }
    }
}