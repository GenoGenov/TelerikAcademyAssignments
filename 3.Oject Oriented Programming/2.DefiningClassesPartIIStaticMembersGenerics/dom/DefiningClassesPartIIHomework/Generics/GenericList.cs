using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;
namespace Generics
{
    public class GenericList<T>
    {
        #region Fields

        private const int DEFAULT_CAPACITY = 8;

        private T[] arr;

        #endregion

        #region Constructors

        public GenericList(int capacity)
        {
            this.Count = 0;
            this.arr = new T[capacity];
        }

        public GenericList() : this(DEFAULT_CAPACITY)
        {
        }

        #endregion

        #region Properties

        public int Capacity
        {
            get { return this.arr.Length; }
        }

        public int Count { get; private set; }

        #endregion

        #region Indexer

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("index was out of range");
                }
                return this.arr[index];
            }
        }

        #endregion

        #region Methods

        public void Add(T element)
        {
            if (Count == Capacity)
            {
                Grow();
            }
            arr[Count] = element;
            this.Count++;
        }

        private void Grow()
        {
            var buffer = new T[Count];
            Array.Copy(arr, 0, buffer, 0, Count);
            this.arr = new T[Capacity*2];
            Array.Copy(buffer, 0, this.arr, 0, this.Count);
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("index was out of range");
            }

            T element = this.arr[index];
            Array.Copy(this.arr, index + 1, this.arr, index, this.Count - index - 1);
            this.arr[this.Count - 1] = default(T);
            this.Count--;
            return element;
        }

        public void Insert(int index, T element)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("index was out of range");
            }
            if (this.Count + 1 == this.Capacity)
            {
                Grow();
            }

            Array.Copy(this.arr, index, this.arr, index + 1, this.Count - index);

            this.arr[index] = element;
            this.Count++;
        }

        public void Clear()
        {
            this.Count = 0;
            this.arr = new T[DEFAULT_CAPACITY];
        }

        public int Find(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.arr[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        public T Min()
        {
            if (!(this.arr[0] is IComparable))
            {
                throw new InvalidOperationException("type is not comparable");
            }
            if (this.Count == 0)
            {
                throw new InvalidOperationException("list contains 0 elements");
            }
            T min = this.arr[0];
            for (int i = 1; i < this.Count; i++)
            {
                var comparable = min as IComparable;
                if (comparable != null && comparable.CompareTo(this.arr[i]) > 0)
                {
                    min = this.arr[i];
                }
            }
            return min;
        }

        public T Max()
        {
            if (!(this.arr[0] is IComparable))
            {
                throw new InvalidOperationException("type is not comparable");
            }
            if (this.Count == 0)
            {
                throw new InvalidOperationException("list contains 0 elements");
            }
            T max = this.arr[0];
            for (int i = 1; i < this.Count; i++)
            {
                var comparable = max as IComparable;
                if (comparable != null && comparable.CompareTo(this.arr[i]) < 0)
                {
                    max = this.arr[i];
                }
            }
            return max;
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            var b = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                b.Append(this.arr[i]);
                b.Append(",");
            }
            b = new StringBuilder(b.ToString().Trim(','));
            b.Append(string.Format("\nCapacity: {0}\nCount: {1}\n", this.Capacity, this.Count));
            return b.ToString();
        }

        #endregion
    }
}