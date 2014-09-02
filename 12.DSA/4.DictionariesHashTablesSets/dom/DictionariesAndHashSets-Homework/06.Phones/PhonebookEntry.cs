namespace _06.Phones
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PhonebookEntry
    {
        private HashSet<string> names;

        public PhonebookEntry(ICollection<string> names, string town, string phone)
        {
            this.names = new HashSet<string>(names);
            this.Town = town;
            this.Phone = phone;
        }

        public string Phone { get; set; }

        public string Town { get; set; }

        public string Names
        {
            get
            {
                return string.Join(" ", this.names);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("*****************************");
            sb.Append(this.Names + " - ");
            sb.Append(this.Town + " - ");
            sb.AppendLine(this.Phone);
            sb.AppendLine("*****************************");

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            return this.Names.Length + this.names.Count + this.names.Sum(x => x.GetHashCode())
                   + this.Phone.GetHashCode() + this.Town.GetHashCode();
        }
    }
}