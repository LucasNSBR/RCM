using RCM.Domain.Constants;
using System;

namespace RCM.Domain.Exceptions
{
    public class DataNotModifiedException : Exception
    {
        public DataNotModifiedException() : base(ExceptionMessageConstants.DataNotModifiedExceptionMessage)
        {
        }
    }
}
