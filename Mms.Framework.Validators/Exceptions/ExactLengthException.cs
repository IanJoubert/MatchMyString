using System;

namespace Mms.Framework.Validators.Exceptions
{
    public class ExactLengthException: Exception
    {
        public ExactLengthException(string value, int length) 
            : base($"Not all strings in the file are of the same length. {value} should be of length {length}")
        {
        }
    }
}
