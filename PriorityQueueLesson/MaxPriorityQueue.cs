using System;

namespace HeapPriorityQueueLesson
{
    public class MaxPriorityQueue<T>
        where T : IComparable<T>
    {
        private T[] _heap;

        private int _count;

        public MaxPriorityQueue(int capacity)
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

        public T Max()
        {
            if(IsEmpty())
                throw new ArgumentOutOfRangeException();

            return _heap[1];
        }

        public void Insert(T value)
        {
            if(_count >= _heap.Length - 1)
                Resize(2 * _heap.Length);

            _heap[++_count] = value;
            Swim(_count);
        }


        public T DeleteMax()
        {
            if (IsEmpty())
                throw new ArgumentOutOfRangeException();

            var max = _heap[1];

            Swap(1, _count--);
            Sink(1);

            _heap[_count + 1] = default(T);

            if((_count > 0) && (_count == (_heap.Length - 1) / 4))
                Resize(_heap.Length / 2);

            return max;
        }

        private void Resize(int capacity)
        {
            T[] temp = new T[capacity];

            for (var i = 0; i <= _count; i++)
                temp[i] = _heap[i];

            _heap = temp;
        }

        private bool Less(int i, int j)
        {
            return _heap[i].CompareTo(_heap[j]) < 0;
        }

        private void Swap(int i, int j)
        {
            var swap = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = swap;
        }

        private void Swim(int k)
        {
            while (k > 1 && Less(k/2, k))
            {
                Swap(k, k/2);
                k = k/2;
            }
        }

        private void Sink(int k)
        {
            while (2*k <= _count)
            {
                var j = 2*k;

                if (j < _count && Less(j, j + 1))
                    j++;

                if (!Less(k, j))
                    break;

                Swap(k, j);
                k = j;
            }
        }
    }
}
