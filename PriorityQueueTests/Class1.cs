using System.Collections.Generic;
using HeapPriorityQueueLesson;
using NUnit.Framework;

namespace HeapPriorityQueueTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void MaxPriorityQueueTest()
        {
            var pq = new MaxPriorityQueue<string>(9);

            var results = new List<string>();

            pq.Insert("P");
            pq.Insert("Q");
            pq.Insert("E");

            results.Add(pq.DeleteMax());

            pq.Insert("X");
            pq.Insert("A");
            pq.Insert("M");

            results.Add(pq.DeleteMax());

            pq.Insert("P");
            pq.Insert("L");
            pq.Insert("E");

            results.Add(pq.DeleteMax());
        }

        [Test]
        public void MinPriorityQueueTest()
        {
            var pq = new MinPriorityQueue<string>(9);

            var results = new List<string>();

            pq.Insert("P");
            pq.Insert("Q");
            pq.Insert("E");

            results.Add(pq.DeleteMin());

            pq.Insert("X");
            pq.Insert("A");
            pq.Insert("M");

            results.Add(pq.DeleteMin());

            pq.Insert("P");
            pq.Insert("L");
            pq.Insert("E");

            results.Add(pq.DeleteMin());
        }
    }
}
