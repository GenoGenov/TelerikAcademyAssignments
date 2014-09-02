namespace _06.Phones
{
    using System.Collections.Generic;
    using System.Linq;

    public class Phonebook
    {
        private Dictionary<PhonebookEntry, List<string>> entriesByName;

        private Dictionary<PhonebookEntry, List<string>> entriesByTown;

        public Phonebook(IEnumerable<PhonebookEntry> entries)
        {
            this.entriesByName = new Dictionary<PhonebookEntry, List<string>>();
            this.entriesByTown = new Dictionary<PhonebookEntry, List<string>>();

            foreach (var entry in entries)
            {
                this.entriesByName.Add(entry, new List<string>() { entry.Names });
                this.entriesByTown.Add(entry, new List<string>() { entry.Town });
            }
        }

        public List<PhonebookEntry> Find(string name)
        {
            var lists = this.entriesByName.Values;
            var listResult = new List<PhonebookEntry>();
            foreach (var list in lists)
            {
                if (list != null)
                {
                    if (list.Any(x => x.ToLower().Contains(name)))
                    {
                        listResult.Add(
                            this.entriesByName.FirstOrDefault(x => x.Value.Any(y => y.ToLower().Contains(name))).Key);
                    }
                }
            }

            return listResult;
        }

        public List<PhonebookEntry> Find(string name, string town)
        {
            var listsNames = this.entriesByName.Values;
            var resultNames = new List<PhonebookEntry>();
            foreach (var list in listsNames)
            {
                if (list != null)
                {
                    if (list.Any(x => x.ToLower().Contains(name)))
                    {
                        resultNames.Add(
                            this.entriesByName.FirstOrDefault(x => x.Value.Any(y => y.ToLower().Contains(name))).Key);
                    }
                }
            }

            var listsTowns = this.entriesByTown.Values;
            var resultTowns = new List<PhonebookEntry>();
            foreach (var list in listsTowns)
            {
                if (list != null)
                {
                    if (list.Any(x => x.ToLower().Contains(town)))
                    {
                        resultTowns.Add(
                            this.entriesByTown.FirstOrDefault(x => x.Value.Any(y => y.ToLower().Contains(town))).Key);
                    }
                }
            }

            return resultNames.Intersect(resultTowns).ToList();
        }
    }
}