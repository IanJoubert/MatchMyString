using System.Collections.Generic;
using System.Linq;
using Mms.Framework.Validators;

namespace Mms.Business.Services
{
    public class FileValidationService: IFileValidationService
    {
        private readonly List<IStringValidator> _validators;

        public FileValidationService(IAlphanumericValidator alphanumericValidator, INonRepeatablesValidator nonRepeatablesValidator)
        {
            _validators = new List<IStringValidator>
            {
                alphanumericValidator,
                nonRepeatablesValidator
            };
        }

        public bool Verify(string file)
        {
            var strings = FileHelper.FileToArray(file);
            _validators.Add(new ExactLengthValidator(strings.First().Length));
            return !(from t in strings from v in _validators where !v.Validate(t) select t).Any();
        }
    }
}
