using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animals.Enums;

namespace Animals
{
    public class Kitten:Cat
    {
        public Kitten(string name, int age) : base(name, age, Sex.Female)
        {
        }
    }
}
