namespace _2.SecondRefactoringProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// dsfsgwrggrew.wegwergw
    /// </summary>
    internal class PersonFactory
    {
        private enum Gender
        {
            Male,
            Female
        }

        public void CreatePerson(int years)
        {
            Person newPerson = new Person();
            newPerson.Years = years;
            if (years % 2 == 0)
            {
                newPerson.Name = "TheBatka";
                newPerson.Gender = Gender.Male;
            }
            else
            {
                newPerson.Name = "TheChick";
                newPerson.Gender = Gender.Female;
            }
        }

        private class Person
        {
            public Gender Gender { get; set; }

            public string Name { get; set; }

            public int Years { get; set; }
        }
    }
}