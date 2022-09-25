namespace Algorithms.Interfaces
{
    internal interface IAsyncSort<T> where T : IComparable<T>
    {
        ICollection<T> AsyncSort(ICollection<T> values);
    }
}
