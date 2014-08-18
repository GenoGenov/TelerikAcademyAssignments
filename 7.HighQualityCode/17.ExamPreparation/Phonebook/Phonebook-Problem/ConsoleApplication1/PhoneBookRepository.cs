namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    internal class PhoneBookRepository : IPhonebookRepository
    {
        private Dictionary<string, PersonInfoModel> dict = new Dictionary<string, PersonInfoModel>();

        private MultiDictionary<string, PersonInfoModel> multidict = new MultiDictionary<string, PersonInfoModel>(false);

        private OrderedSet<PersonInfoModel> sorted = new OrderedSet<PersonInfoModel>();

        public bool AddPhone(PersonInfoModel model)
        {
            string name2 = model.Name.ToLowerInvariant();
            PersonInfoModel entry;
            bool flag = !this.dict.TryGetValue(name2, out entry);
            if (flag)
            {
                entry = new PersonInfo();
                entry.Name = model.Name;
                entry.Phones = new SortedSet<string>();
                this.dict.Add(name2, entry);

                this.sorted.Add(entry);
            }

            foreach (var num in nums)
            {
                this.multidict.Add(num, entry);
            }

            entry.Phones.UnionWith(nums);
            return flag;
        }

        public int ChangePhone(string oldent, string newent)
        {
            var found = this.multidict[oldent].ToList();
            foreach (var entry in found)
            {
                entry.Phones.Remove(oldent);
                this.multidict.Remove(oldent, entry);

                entry.Phones.Add(newent);
                this.multidict.Add(newent, entry);
            }

            return found.Count;
        }

        public PersonInfoModel[] ListEntries(int first, int num)
        {
            if (first < 0 || first + num > this.dict.Count)
            {
                Console.WriteLine("Invalid start index or count.");
                return null;
            }

            PersonInfo[] list = new PersonInfo[num];

            for (int i = first; i <= first + num - 1; i++)
            {
                PersonInfo entry = this.sorted[i];
                list[i - first] = entry;
            }

            return list;
        }
    }
}