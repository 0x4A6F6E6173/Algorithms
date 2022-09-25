namespace Algorithms.Interfaces
{
    internal interface IGenericSort<T> where T : IComparable<T>
    {
        IList<T> GenericSort(IList<T> values);
    }
}
