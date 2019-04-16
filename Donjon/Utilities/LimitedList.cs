using System;
using System.Collections;
using System.Collections.Generic;

namespace Donjon.Utilities
{
    public class LimitedList<T> : IEnumerable<T>
    {
        private List<T> list = new List<T>();
        public LimitedList(int capacity)
        {
            Capacity = Math.Max(0, capacity);
        }

        public int Capacity { get; }
        public int Count => list.Count;

        public bool IsFull => Capacity <= Count;

        public T this[int i]
        {
            get { return list[i]; }
            set { list[i] = value; }
        }

        public bool Add(T item)
        {
            if (IsFull) return false;
            list.Add(item);
            return true;
        }

        public bool Remove(T item) => list.Remove(item);

        public IEnumerator<T> GetEnumerator() => list.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
