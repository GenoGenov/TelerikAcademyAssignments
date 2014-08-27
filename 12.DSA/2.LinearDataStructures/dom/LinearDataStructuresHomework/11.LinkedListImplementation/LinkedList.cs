using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.LinkedListImplementation
{
    using System.Collections;

    public class LinkedList<T>:IEnumerable<T>
        where T:IComparable<T>
    {
        private LinkedListNode<T> head;

        private LinkedListNode<T> tail;

        public LinkedList()
        {
            this.Count = 0;
        } 

        public int Count { get; private set; }

        public void AddFirst(T value)
        {
            var node = new LinkedListNode<T>(value);
            if (this.Count==0)
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                this.head.Previous = node;
                node.Next = this.head;
                this.head = node;
            }
            this.Count++;
        }

        public void AddLast(T value)
        {
            var node = new LinkedListNode<T>(value);
            if (this.Count==0)
            {
                node.Next = node;
                node.Previous = node;
                this.head = node;
                this.tail = node;
            }
            else
            {
                this.tail.Next = node;
                node.Previous = this.tail;
                this.tail = node;
            }
            this.Count++;
        }

        public void AddBefore(LinkedListNode<T> existing, T value)
        {
            var newNode = new LinkedListNode<T>(value);
            var prev = existing.Previous;
            prev.Next = newNode;
            newNode.Previous = existing.Previous;
            newNode.Next = existing;
            existing.Previous = newNode;
            this.Count++;
        }

        public void AddAfter(LinkedListNode<T> existing, T value)
        {
            var newNode = new LinkedListNode<T>(value);
            newNode.Next = existing.Next;
            if (existing.Next==null)
            {
                this.AddLast(value);
            }
            existing.Next.Previous = newNode;
            existing.Next = newNode;
            newNode.Previous = existing;
            
        }

        public void RemoveFirst()
        {
            if (this.Count>0)
            {
                this.head.Next.Previous = null;
                this.head=this.head.Next;
            }
        }

        public void RemoveLast()
        {
            this.tail.Previous.Next = null;
            this.tail = this.tail.Previous;
        }

        public class LinkedListNode<T>
        {
            public T Value { get; set; }

            public LinkedListNode<T> Next { get; set; }

            public  LinkedListNode<T> Previous { get; set; }

            public LinkedListNode(T value)
            {
                this.Value = value;
            }
        }

        public LinkedListNode<T> Find(T value)
        {
            var temp = this.head;
            while (temp!=null)
            {
                if (temp.Value.CompareTo(value)==0)
                {
                    break;
                }
                temp = temp.Next;
            }
            return temp;
        }

        public IEnumerator<T> GetEnumerator()
        {

            var root = this.head;
            while (root!=null)
            {
                yield return root.Value;
                root = root.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
