using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _03.StringCheckerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StringCheckerService" in both code and config file together.
    public class StringCheckerSvc : IStringCheckerSvc
    {
        public int CheckStrings(string first, string second)
        {
            int count = 0;
            int index = second.IndexOf(first);
            while (second.Substring(index).IndexOf(first)>-1)
            {
                count++;
                index = index + first.Length;
            }
            return count;
        }
    }
}
