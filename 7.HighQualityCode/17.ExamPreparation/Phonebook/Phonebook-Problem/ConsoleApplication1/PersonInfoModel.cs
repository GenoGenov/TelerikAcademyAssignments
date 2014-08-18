namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;

    public abstract class PersonInfoModel : IPersonInfo
    {

        protected PersonInfoModel(string name, ISet<string> phoneNumbers)
        {
            this.Phones = phoneNumbers;
            this.Name = name;
        }

        public IEnumerable<string> Phones { get; set; }

        public string Name { get; set; }

        public int CompareTo(IPersonInfo other)
        {
            return string.Compare(this.Name.ToLowerInvariant(), other.Name.ToLowerInvariant(), StringComparison.Ordinal);
        }

        public abstract override string ToString();
    }
}