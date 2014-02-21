using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animals.Enums;

namespace Animals
{
    public abstract class Animal : ISound
    {
        #region Fields

        protected int age;
        protected string name;

        protected Sex sex;

        #endregion


        #region Constructors

        protected Animal(string name, Sex sex, int age)
        {
            this.Age = age;
            this.Sex = sex;
            this.Name = name;
        }

        public Animal()
        {
        }

        #endregion


        #region Properties

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("name cannot be null or empty");
                }
                name = value;
            }
        }

        public Sex Sex { get; private set; }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("age must be atleast 1");
                }
                age = value;
            }
        }

        #endregion


        #region Methods

        public abstract void MakeSound();

        public void Identify()
        {
            Console.Write("I am " + GetType().Name + " and i make ");
            MakeSound();
        }

        public static double CalcAge(IEnumerable<Animal> animals)
        {
            return animals.Average(x => x.Age);
        }

        #endregion

    }
}