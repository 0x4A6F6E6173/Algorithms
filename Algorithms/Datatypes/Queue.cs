using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Datatypes
{
    public class Queue<T>
    {
        #region MemberVariables
        private T[] queue;
        private int head;
        private int tail; 
        #endregion

        #region Constructor
        public Queue()
        {
            queue = new T[10]; // default value
            head = 0;
            tail = 0;
        }
        #endregion

        #region PublicMemberFunctions
        public void Enqueue(T value)
        {
            bool isHeadOnTail = ((head + 1) % queue.Length) == tail;
            if (isHeadOnTail)
                ExpandQueue();

            queue[head] = value;
            head = ++head % queue.Length;
        }

        public void Enqueue(List<T> values)
        {
            foreach (var value in values)
            {
                Enqueue(value);
            }
        }

        public T Dequeue()
        {
            return queue[(tail++ % queue.Length)]; // postfix decrement
        }

        public int Count()
        {
            bool headHasLapped = head < tail;
            if (headHasLapped)
                return (head + queue.Length) - tail;
            else
                return head - tail;
        }
        #endregion

        #region PrivateMemberFunctions
        private void ExpandQueue()
        {
            var newQueue = new T[queue.Length * 2];
            Array.Copy(queue, newQueue, queue.Length);
            queue = newQueue;
        }

        private void ShrinkQueue()
        {
            // If the queue has consistently stayed below 1/4 of the available space
            // for n operations, then shrink the queue.
        }
        #endregion
    }
}
