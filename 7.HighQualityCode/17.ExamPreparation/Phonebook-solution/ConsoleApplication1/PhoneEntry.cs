namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PhoneEntry : IComparable<PhoneEntry>
    {
        private string name;

        private string nameForComparison;

        public SortedSet<string> PhoneNumbers { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.nameForComparison = value.ToLowerInvariant();
            }
        }

        public int CompareTo(PhoneEntry other)
        {
            return this.nameForComparison.CompareTo(other.nameForComparison);
        }

        public override string ToString()
        {
            StringBuilder entryToString = new StringBuilder();
            entryToString.Append('[');
            entryToString.Append(this.Name);
            entryToString.Append(": ");
            bool isFirstPhoneNumber = true;
            foreach (var phone in this.PhoneNumbers)
            {
                if (isFirstPhoneNumber)
                {
                    isFirstPhoneNumber = false;
                }
                else
                {
                    entryToString.Append(", ");
                }

                entryToString.Append(phone);
            }

            entryToString.Append(']');
            return entryToString.ToString();
        }
    }
}