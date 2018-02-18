using System;

namespace Mms.Framework.Exceptions
{
    public class AlphanumericException: Exception
    {
        public AlphanumericException() : base("Not all characters in the file are alphanumeric.")
        {
        }
    }
}
