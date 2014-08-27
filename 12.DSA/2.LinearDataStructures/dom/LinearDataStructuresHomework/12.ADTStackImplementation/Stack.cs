using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.ADTStackImplementation
{
    public class MyStack<T>:IEnumerable<T>
    {
        private T[] arr;

        private const int InitialArraySize = 4;

        private const int GrowthFactor = 2;

        private int head;

        public int Count
        {
            get
            {
                return this.head;
            }
        }

        public int Capacity
        {
            get
            {
                return this.arr.Length;
            }
        }

        public MyStack()
        {
            this.arr=new T[InitialArraySize];
            this.head = 0;
        }

        public void Push(T value)
        {
            this.GrowIfNeeded();
            this.arr[this.head] = value;
            this.head++;
        }

        public T Pop()
        {
            if (this.head==0)
            {
                throw new InvalidOperationException("The stack is already empy!");
            }
            this.head--;
            return this.arr[this.head];
        }

        public T Peek()
        {
            if (this.head==0)
            {
                throw new InvalidOperationException("The stack is already empy!");
            }
            return this.arr[this.head-1];
        }

        public void Clear()
        {
            this.head = 0;
        }

        public bool Contains(T value)
        {
            return this.arr.Contains(value);
        }

        public T[] ToArray()
        {
            var result = new T[this.Count];
            var arrIndex = this.Count - 1;
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = this.arr[arrIndex];
                arrIndex--;
            }

            return result;
        }

        public void TrimExess()
        {
            Array.Resize(ref this.arr,this.Count);
        }

        private bool GrowIfNeeded()
        {
            if (this.Count==this.arr.Length)
            {
                Array.Resize(ref arr, arr.Length*GrowthFactor);
                return true;
            }
            return false;
        }



        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.head-1; i >=0; i--)
            {
                yield return this.arr[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
