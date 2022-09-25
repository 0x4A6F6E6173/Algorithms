using Algorithms.Interfaces;
namespace Algorithms.Sorting
{
    public class SelectionSort<T> : IGenericSort<T>
        where T : IComparable<T>
    {
        public IList<T> GenericSort(IList<T> values)
        {
            var sorted = new List<T>(values.Count);
            for (int sortedIndex = 0; sortedIndex < sorted.Count; sortedIndex++)
            {
                var currentBest = values[0];
                for (int valueIndex = 0; valueIndex < values.Count; valueIndex++)
                {

                }

                sorted.Add(currentBest);
            }

            return new List<T>(values);
        }
    }
}
