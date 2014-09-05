using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.HashTable
{
    using System.Collections;
    using System.Collections.Generic;
    public class HashTable<K,T>:IEnumerable<KeyValuePair<K,T>>
    {
        private LinkedList<KeyValuePair<K, T>>[] data;

        public HashSet<K> Keys { get; private set; } 

        private const int InitialCapacity = 16;

        private int cellCount;

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return this.data.Length;
            }
        }

        public HashTable()
        {
            this.data = new LinkedList<KeyValuePair<K, T>>[InitialCapacity];
            this.cellCount = 0;
            this.Count = 0;
            this.Keys=new HashSet<K>();
        }

        public void Add(K key, T value)
        {
            if (this.Keys.Contains(key))
            {
                throw new ArgumentException("Key already added!");
            }

            var index = Math.Abs(key.GetHashCode() % data.Length);
            if (data[index]==null)
            {
                data[index]=new LinkedList<KeyValuePair<K, T>>();
                this.cellCount++;
            }
            data[index].AddFirst(new KeyValuePair<K, T>(key, value));
            this.Keys.Add(key);
            this.Count++;
            this.GrowIfNeeded();
        }

        public T Find(K key)
        {
            if (!this.Keys.Contains(key))
            {
                throw new ArgumentException("Element with this key does not exist");
            }

            var index = Math.Abs(key.GetHashCode() % this.data.Length);
            return data[index].First(x => x.Key.Equals(key)).Value;
        }

        public bool Contains(K key)
        {
            return this.Keys.Contains(key);
        }

        public void Remove(K key)
        {
            if (!this.Keys.Contains(key))
            {
                throw new ArgumentException("No such key exists!");
            }
            var index = Math.Abs(key.GetHashCode() % this.data.Length);
           
            this.data[index].Remove(this.data[index].First(x => x.Key.Equals(key)));
            if (this.data[index].Count == 0)
            {
                this.cellCount--;
                this.data[index] = null;
            }
            this.Count--;
        }

        public void Clear()
        {
            this.data = new LinkedList<KeyValuePair<K, T>>[InitialCapacity];
            this.cellCount = 0;
            this.Count = 0;
            this.Keys = new HashSet<K>();
        }

        public T this[K key]
        {
            get
            {
                return this.Find(key);
            }
            set
            {
                if (!this.Keys.Contains(key))
                {
                    throw new ArgumentException("No such key exists!");
                }
                var index = Math.Abs(key.GetHashCode() % this.data.Length);
                var item = this.data[index].First(x => x.Key.Equals(key));
                this.data[index].Remove(item);
                this.Add(key,value);
            }
        }

        private void MapArray(LinkedList<KeyValuePair<K, T>>[] resized)
        {
            
            for (int i = 0; i < this.data.Length; i++)
            {
                if (this.data[i] != null)
                {
                    int index = Math.Abs(this.data[i].First.Value.Key.GetHashCode() % resized.Length);
                    resized[index] = new LinkedList<KeyValuePair<K, T>>();

                    foreach (var val in this.data[i])
                    {
                        resized[index].AddFirst(val);
                    }
                }
            }
            this.data = resized;
        }

        private bool GrowIfNeeded()
        {
            if (this.cellCount >= this.data.Length * (0.75))
            {
                var resized = new LinkedList<KeyValuePair<K, T>>[data.Length * 2];
                this.MapArray(resized);
                return true;
            }
            return false;
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (var list in this.data)
            {
                if (list!=null)
                {
                    foreach (var keyValuePair in list)
                    {
                        yield return keyValuePair;
                    }
                }
                
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
