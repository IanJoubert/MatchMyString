using System;

namespace Mms.Framework.Validators.Exceptions
{
    public class RepeatingCharactersException: Exception
    {
        public RepeatingCharactersException() : base("Some strings in the file has repeating characters.")
        {
        }
    }
}
