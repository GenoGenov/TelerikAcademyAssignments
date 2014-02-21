using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animals.Enums;

namespace Animals
{
    class Dog:Animal
    {
        public Dog(string name, int age, Sex sex) : base(name, sex, age)
        {
            
        }
        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }

    }
}
