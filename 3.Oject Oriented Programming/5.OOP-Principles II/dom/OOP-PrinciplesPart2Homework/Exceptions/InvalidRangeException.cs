using System;
using System.Linq;

namespace Exceptions
{
    public class InvalidRangeException<T> : ApplicationException
    {
        public InvalidRangeException(T start, T end) : base(string.Format("Items must be in the range [{0}...{1}]", start.ToString(), end.ToString()))
        {
            this.Start = start;
            this.End = end;
        }

        public T Start { get; set; }

        public T End { get; set; }
    }
}