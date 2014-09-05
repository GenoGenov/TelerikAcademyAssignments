using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PriorityQueue
{
    using System.Collections;

    public class PriorityQueue<T>:IEnumerable<T>
        where T:IComparable<T>
    {
        private T[] data;

        private const int InitialSize = 16;

        private int tail;

        public int Count { get; private set; }

        public PriorityQueue()
        {
            this.data=new T[InitialSize];
            this.tail = 0;
        }

        public void Enqueue(T item)
        {
            if (this.Count==this.data.Length)
            {
                this.Resize();
            }
            this.data[this.tail] = item;
            this.tail++;
            this.AddRebalance();
            this.Count++;

        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }
            return this.data[0];
        }

        public T Dequeue()
        {
            if (this.Count==0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }

            T item = this.data[0];
            this.data[0] = this.data[this.tail-1];
            this.tail--;
            this.RemoveRebalance();
            this.Count--;

            return item;
        }

        private void Resize()
        {
            Array.Resize(ref this.data, this.data.Length*2);
        }

        private void AddRebalance()
        {
            int last = this.tail-1;
            int parentIndex = (this.tail - 1) / 2;
                while (last>0)
                {
                    if (this.data[parentIndex].CompareTo(data[last])<0)
                    {
                         this.Swap(parentIndex, last);
                    }
                    last = parentIndex;
                    parentIndex = (last - 1) / 2;

                }
        }

        private void RemoveRebalance()
        {
            int root = 0;
            int left = 1;
            int right = 2;
            while (this.data[root].CompareTo(this.data[left]) < 0 && left < this.tail)
                {
                    this.Swap(root, left);
                    root = left;
                    left = root * 2 + 1;
                }
            root = 0;
            while (this.data[root].CompareTo(this.data[right]) < 0 && right < this.tail)
                {
                    this.Swap(root, right);
                    root = right;
                    right = root * 2 + 2;
                }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = this.data[firstIndex];
            this.data[firstIndex] = this.data[secondIndex];
            this.data[secondIndex] = temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int current = 0;
            while (current<this.tail)
            {
                current++;
                yield return this.data[current - 1];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
