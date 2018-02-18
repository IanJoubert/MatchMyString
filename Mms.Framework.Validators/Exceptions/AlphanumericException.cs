using System;

namespace Mms.Framework.Validators.Exceptions
{
    public class AlphanumericException: Exception
    {
        public AlphanumericException() : base("Not all characters in the file are alphanumeric.")
        {
        }
    }
}
