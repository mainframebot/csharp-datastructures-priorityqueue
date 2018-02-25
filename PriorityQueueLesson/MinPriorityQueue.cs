using System;

namespace HeapPriorityQueueLesson
{
    public class MinPriorityQueue<T>
        where T : IComparable<T>
    {
        private T[] _heap;

        private int _count;

        public MinPriorityQueue(int capacity)
        {
            _heap = new T[capacity + 1];
            _count = 0;
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public int Count()
        {
            return _count;
        }

        public T Min()
        {
            if (IsEmpty())
                throw new ArgumentOutOfRangeException();

            return _heap[1];
        }

        public void Insert(T value)
        {
            if (_count >= _heap.Length - 1)
                Resize(2 * _heap.Length);

            _heap[++_count] = value;
            Swim(_count);
        }


        public T DeleteMin()
        {
            if (IsEmpty())
                throw new ArgumentOutOfRangeException();

            Swap(1, _count);

            var min = _heap[_count--];

            Sink(1);

            _heap[_count + 1] = default(T);

            if ((_count > 0) && (_count == (_heap.Length - 1) / 4))
                Resize(_heap.Length / 2);

            return min;
        }

        private void Resize(int capacity)
        {
            T[] temp = new T[capacity];

            for (var i = 0; i <= _count; i++)
                temp[i] = _heap[i];

            _heap = temp;
        }

        private bool Greater(int i, int j)
        {
            return _heap[i].CompareTo(_heap[j]) > 0;
        }

        private void Swap(int i, int j)
        {
            var swap = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = swap;
        }

        private void Swim(int k)
        {
            while (k > 1 && Greater(k / 2, k))
            {
                Swap(k, k / 2);
                k = k / 2;
            }
        }

        private void Sink(int k)
        {
            while (2 * k <= _count)
            {
                var j = 2 * k;

                if (j < _count && Greater(j, j + 1))
                    j++;

                if (!Greater(k, j))
                    break;

                Swap(k, j);
                k = j;
            }
        }
    }
}
