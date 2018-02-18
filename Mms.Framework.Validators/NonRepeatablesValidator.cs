using System.Collections.Generic;
using System.Linq;
using Mms.Framework.Validators.Exceptions;

namespace Mms.Framework.Validators
{
    public class NonRepeatablesValidator: INonRepeatablesValidator
    {
        public bool Validate(string item)
        {
            return HashSetTest(item.ToCharArray());
        }

        private static bool HashSetTest(IEnumerable<char> items)
        {
            if (items.All(new HashSet<char>().Add))
            {
                return true;
            }
            throw new RepeatingCharactersException();
        }
    }
}
