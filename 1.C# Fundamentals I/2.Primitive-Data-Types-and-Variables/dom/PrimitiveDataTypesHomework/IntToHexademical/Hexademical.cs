using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntToHexademical
{
    class Hexademical
    {
        static void Main(string[] args)
        {
            int variable = 0xFE;
            string hex=variable.ToString("X");
            Console.WriteLine("Number in hexademical: {0}\nNumber in Integer: {1}",hex,variable);
        }
    }
}
