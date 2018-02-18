using System.Collections.Generic;
using System.Linq;
using Mms.Framework.Comparers;

namespace Mms.Business.Services
{
    public class StringMatcherService : IMatcherService
    {
        private readonly IStringComparer _comparer;
        public StringMatcherService(IStringComparer comparer)
        {
            _comparer = comparer;
        }

        public string GetMatches(string searchString, string file)
        {
            var strings = FileHelper.FileToArray(file);
            return string.Join(",", strings.Where(s => _comparer.Compare(s, searchString)));
        }
    }
}
