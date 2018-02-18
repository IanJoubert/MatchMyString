using Mms.Framework.Validators.Exceptions;

namespace Mms.Framework.Validators
{
    public class ExactLengthValidator : IExactLengthValidator
    {
        public int Length { get; }

        public ExactLengthValidator(int length)
        {
            Length = length;
        }
        public bool Validate(string item)
        {

            if (item.Length == Length)
            {
                return true;
            }
            throw new ExactLengthException(item, Length);
        }
    }
}
