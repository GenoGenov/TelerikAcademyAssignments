namespace _14.ImplementLinkedQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedQueue<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private QueueNode<T> head;

        private QueueNode<T> tail;

        public LinkedQueue()
        {
            this.Count = 0;
        }

        public int Count { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            var temp = this.head;
            while (temp != null)
            {
                yield return temp.Value;
                temp = temp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Enqueue(T value)
        {
            var node = new QueueNode<T>(value);
            if (this.Count == 0)
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                this.tail.Next = node;
                this.tail = node;
            }
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Linked Queue is empty!");
            }
            var result = this.head.Value;
            this.head = this.head.Next;
            this.Count--;
            return result;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Linked Queue is empty!");
            }
            return this.head.Value;
        }

        public void Clear()
        {
            this.Count = 0;
            this.head = null;
            this.tail = null;
        }

        public bool Contains(T value)
        {
            foreach (var val in this)
            {
                if (val.CompareTo(value) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public T[] ToArray()
        {
            var result = new T[this.Count];
            var temp = this.head;
            var index = 0;
            while (temp != null)
            {
                result[index] = temp.Value;
                temp = temp.Next;
                index++;
            }
            return result;
        }

        private class QueueNode<T>
        {
            public QueueNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }

            public QueueNode<T> Next { get; set; }
        }
    }
}