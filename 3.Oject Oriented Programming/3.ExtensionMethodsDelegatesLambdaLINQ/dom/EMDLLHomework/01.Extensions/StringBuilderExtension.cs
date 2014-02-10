using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Extensions
{
    public static class StringBuilderExtension
    {
        public static StringBuilder SubString(this StringBuilder b, int index, int length)
        {
            if (index >= b.Length || index < 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            if (length <= 0 || length > b.Length - index - 1)
            {
                throw new ArgumentOutOfRangeException("length");
            }
            return new StringBuilder(b.ToString().Substring(index,length));
        }
    }
}
