namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class OptimisedPhoneBookRepository : IPhonebookRepository
    {
        private List<PersonInfoModel> entries = new List<PersonInfoModel>();

        public bool AddPhone(PersonInfoModel entryToAdd)
        {
            var sameNameEntries = from e in this.entries where e.Name.ToLowerInvariant() == entryToAdd.Name.ToLowerInvariant() select e;
            bool addedNewEntry;
            if (sameNameEntries.Count() == 0)
            {

                this.entries.Add(entryToAdd);
                addedNewEntry = true;
            }
            else if (sameNameEntries.Count() == 1)
            {
                PersonInfoModel oldEntry = sameNameEntries.First();
                foreach (var phoneNumber in entryToAdd.Phones)
                {
                    oldEntry.Phones.Add(phoneNumber);
                }

                addedNewEntry = false;
            }
            else
            {
                Console.WriteLine("Duplicated name in the phonebook found: " + entryToAdd.Name);
                return false;
            }

            return addedNewEntry;
        }

        public int ChangePhone(string oldent, string newent)
        {
            var list = from e in this.entries where e.Phones.Contains(oldent) select e;

            int phoneNumbers = 0;
            foreach (var entry in list)
            {
                entry.Phones.Remove(oldent);
                entry.Phones.Add(newent);
                phoneNumbers++;
            }

            return phoneNumbers;
        }

        public PersonInfoModel[] ListEntries(int start, int num)
        {
            if (start < 0 || start + num > this.entries.Count)
            {
                throw new ArgumentOutOfRangeException("start", "Invalid start index or count.");
            }

            this.entries.Sort();
            var ent = new PersonInfo[num];
            for (int i = start; i <= start + num - 1; i++)
            {
                PersonInfo entry = this.entries[i];
                ent[i - start] = entry;
            }

            return ent;
        }
    }
}