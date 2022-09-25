using Algorithms.Sorting;

namespace TestAlgorithms.SortingAlgorithms
{
    public class Test_BubbleSort
    {
        [Test]
        public void Test_BubbleSort_UnsortedInput()
        {
            var values = new List<int> { 9, 3, 7, 2, 8, 4, 5, 6, 1 };
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Assert.That(new BubbleSort<int>().GenericSort(values), Is.EqualTo(expected));
        }

        [Test]
        public void Test_BubbleSort_AlreadySortedInput()
        {
            var values = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            new BubbleSort<int>().GenericSort(values);
            Assert.That(new BubbleSort<int>().GenericSort(values), Is.EqualTo(expected));
        }
    }
}