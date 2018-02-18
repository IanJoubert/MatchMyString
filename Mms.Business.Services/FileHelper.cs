using System.Text.RegularExpressions;

namespace Mms.Business.Services
{
    internal class FileHelper
    {
        private const char Seperator = ',';
        internal static string[] FileToArray(string file)
        {
            // remove line breaks and spaces
            file = Regex.Replace(file, @"\s+", string.Empty);
            return file.Split(Seperator);
        }
    }
}
