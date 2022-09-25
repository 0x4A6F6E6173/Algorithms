using Algorithms.Interfaces;

namespace Algorithms.Sorting
{
    public class BubbleSort<T> : IGenericSort<T>
        where T : IComparable<T>
    {
        public IList<T> GenericSort(IList<T> values)
        {
            var temp = values[0];
            bool completedSort = false;
            while (!completedSort)
            {
                completedSort = true;
                for (int index = 1; index < values.Count; index++)
                {
                    bool isOrderIncorrect = values[index - 1].CompareTo(values[index]) >= 0;
                    if (isOrderIncorrect)
                    {
                        completedSort = false;
                        temp = values[index - 1];
                        values[index - 1] = values[index];
                        values[index] = temp;
                    }
                }
            }

            return values;
        }
    }
}