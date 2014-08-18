namespace ConsoleApplication1
{
    using System.Collections.Generic;
    using System.Text;

    internal class PersonInfo : PersonInfoModel
    {
        public PersonInfo(string name, ISet<string> phoneNumbers)
            : base(name, phoneNumbers)
        {
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Clear();
            sb.Append('[');

            sb.Append(this.Name);
            bool flag = true;
            foreach (var phone in this.Phones)
            {
                if (flag)
                {
                    sb.Append(": ");
                    flag = false;
                }
                else
                {
                    sb.Append(", ");
                }

                sb.Append(phone);
            }

            sb.Append(']');
            return sb.ToString();
        }
    }
}