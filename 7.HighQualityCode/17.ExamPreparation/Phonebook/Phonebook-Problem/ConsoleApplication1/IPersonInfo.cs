namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;

    public interface IPersonInfo : IComparable<IPersonInfo>
    {
        string Name { get; set; }

        IEnumerable<string> Phones { get; set; }
    }
}