namespace Mms.Framework.Comparers
{
    public interface IComparer<in T, in TU>
    {
        bool Compare(T item1, TU item2);
    }
}
