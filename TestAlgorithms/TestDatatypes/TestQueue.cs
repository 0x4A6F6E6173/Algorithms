using Algorithms.Datatypes;

namespace TestAlgorithms.TestDatatypes
{
    internal class Test_Queue
    {
        [Test]
        public void Test_Queue_Count()
        {
            var queue = new Algorithms.Datatypes.Queue<int>();
            var addedElements = 7;
            for (int index = 0; index < addedElements; index++)
                queue.Enqueue(1);

            Assert.That(queue.Count(), Is.EqualTo(addedElements));
        }

        [Test]
        public void Test_Queue_CountRollOver()
        {
            // Enqueue and Dequeue enough values such that the head pointer rolls over
            // But without the queue expanding, which it does if the underlying array
            // gets filled out.

            var queue = new Algorithms.Datatypes.Queue<int>();
            var valuesToBeDequeued = 7;
            for (int index = 0; index < valuesToBeDequeued; index++)
            {
                queue.Enqueue(1);
                queue.Dequeue();
            }

            var valuesToBeCounted = 4;
            for (int index = 0; index < valuesToBeCounted; index++)
                queue.Enqueue(1);

            Assert.That(queue.Count(), Is.EqualTo(valuesToBeCounted));

        }

        [Test]
        public void Test_Queue_Enqueue()
        {
            var queue = new Algorithms.Datatypes.Queue<int>();
            queue.Enqueue(1);
            Assert.That(queue.Count(), Is.EqualTo(1));
        }

        [Test]
        public void Test_Queue_Dequeue()
        {
            var queue = new Algorithms.Datatypes.Queue<int>();
            var value = 1;
            queue.Enqueue(value);
            Assert.That(queue.Dequeue(), Is.EqualTo(value));
        }

        [Test]
        public void Test_Queue_QueueExpansion()
        {
            var queue = new Algorithms.Datatypes.Queue<int>();
            var valuesToBeCounted = 11;
            for (int index = 0; index < valuesToBeCounted; index++)
                queue.Enqueue(1);

            Assert.That(queue.Count(), Is.EqualTo(valuesToBeCounted));
        }
    }
}
