using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.HashTable;

namespace _05.HashedSet
{
    using System.Collections;

    public class HashedSet<T>:IEnumerable<T>
    {
        private HashTable<int, T> data;

        public HashedSet()
        {
            this.data=new HashTable<int, T>();
        }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public void Add(T item)
        {
            try
            {
                this.data.Add(item.GetHashCode(), item);
            }
            catch (ArgumentException e)
            {
                
            }
            
        }

        public void Find(T item)
        {
            this.data.Find(item.GetHashCode());
        }

        public void Remove(T item)
        {
            this.data.Remove(item.GetHashCode());
        }

        public void Clear()
        {
            this.data.Clear();
        }

        public HashedSet<T> Union(IEnumerable<T> other)
        {
            var newSet = new HashedSet<T>();

            foreach (var val in this.data)
            {
                newSet.Add(val.Value);
            }

            foreach (var item in other)
            {
                if (!this.Contains(item))
                {
                    newSet.Add(item);
                }
            }

            return newSet;
        }

        public HashedSet<T> Intersect(IEnumerable<T> other)
        {
            var newSet = new HashedSet<T>();

            foreach (var item in other)
            {
                if (this.Contains(item))
                {
                    newSet.Add(item);
                }
            }

            return newSet;
        }

        public bool Contains(T item)
        {
            return this.data.Keys.Contains(item.GetHashCode());
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.data)
            {
                yield return item.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
