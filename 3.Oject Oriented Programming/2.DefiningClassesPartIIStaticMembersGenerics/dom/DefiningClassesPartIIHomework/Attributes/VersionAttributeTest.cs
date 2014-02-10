using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    [Version("2.11")]
    internal class VersionAttributeTest
    {
        public static void Main(string[] args)
        {
            Type type = typeof (VersionAttributeTest);

            object[] attr = type.GetCustomAttributes(false);
            foreach (VersionAttribute ver in attr)
            {
                Console.WriteLine("Class version: {0}", ver.Version);
            }
        }
    }
}