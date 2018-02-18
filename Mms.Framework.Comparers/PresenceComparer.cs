using System.Linq;

namespace Mms.Framework.Comparers
{
    public class PresenceComparer: IStringComparer
    {
        public bool Compare(string item1, string item2)
        {
            return DistinctSort(item1).Equals(DistinctSort(item2));
        }

        private static string DistinctSort(string item)
        {
            var arrItem = item.ToCharArray();
            return new string(arrItem.Distinct().OrderBy(x => x).ToArray());
        }
    }
}
