namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;
        private static Random rnd=new Random();

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (T value in this.items)
            {
                if (item.CompareTo(value) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int size = this.items.Count;
            int mid;
            int left = 0;
            int right = size - 1;

            if (item.CompareTo(this.items[left]) < 0 ||
                item.CompareTo(this.items[right]) > 0)
            {
                return false;
            }
            if (item.CompareTo(this.items[left]) == 0)
            {
                return true;
            }

            while (right - left > 1)
            {
                mid = (left + right) / 2;
                if (item.CompareTo(this.items[mid]) <= 0)
                {
                    right = mid;
                }
                else
                {
                    left = mid;
                }
            }

            return item.CompareTo(this.items[right]) == 0;
        }

        public void Shuffle()
        {
            int size = this.items.Count;
            for (int i = size - 1; i > 0; i--)
            {
                int swapIndex = rnd.Next(i + 1);
                if (swapIndex != i)
                {
                    T temp = this.items[swapIndex];
                    this.items[swapIndex] = this.items[i];
                    this.items[i] = temp;
                }
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
