using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _04.HashTable;

public class BiDictionary<T, K, L>
{
    private HashTable<T, List<L>> firstKeyTable;
    private HashTable<K, List<L>> secondKeyTable;
    private HashTable<string, List<L>> bothKeysTable;

    public BiDictionary()
    {
        this.firstKeyTable = new HashTable<T, List<L>>();
        this.secondKeyTable = new HashTable<K, List<L>>();
        this.bothKeysTable = new HashTable<string, List<L>>();
    }

    public void Add(T firstKey, K secondKey, L value)
    {
        if (this.firstKeyTable.Contains(firstKey))
        {
            this.firstKeyTable[firstKey].Add(value);
        }
        else
        {
            this.firstKeyTable.Add(firstKey, new List<L> { value });
        }

        if (this.secondKeyTable.Contains(secondKey))
        {
            this.secondKeyTable[secondKey].Add(value);
        }
        else
        {
            this.secondKeyTable.Add(secondKey, new List<L> { value });
        }

        if (this.bothKeysTable.Contains(firstKey.ToString() + secondKey.ToString()))
        {
            this.bothKeysTable[firstKey.ToString() + secondKey.ToString()].Add(value);
        }
        else
        {
            this.bothKeysTable.Add(firstKey.ToString() + secondKey.ToString(), new List<L> { value });
        }
    }

    public IEnumerable FindByFistKey(T key)
    {
        return this.firstKeyTable[key];
    }

    public IEnumerable FindBySecondKey(K key)
    {
        return this.secondKeyTable[key];
    }

    public IEnumerable FindByBothKeys(T firstKey, K secondKey)
    {
        return this.bothKeysTable[firstKey.ToString() + secondKey.ToString()];
    }
}