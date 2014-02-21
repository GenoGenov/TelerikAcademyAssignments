using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animals.Enums;

namespace Animals
{
    class Tomcat:Cat
    {
        public Tomcat(string name, int age) : base(name, age, Sex.Male)
        {
        }
    }
}
