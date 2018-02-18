using System.Linq;
using Mms.Framework.Validators.Exceptions;

namespace Mms.Framework.Validators
{
    public class AlphanumericValidator: IAlphanumericValidator
    {
        public bool Validate(string item)
        {
            if (!item.All(char.IsLetterOrDigit))
            {
                throw new AlphanumericException();
            }
            return true;
        }
    }
}
