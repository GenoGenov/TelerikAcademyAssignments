using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Teacher : Person
    {
        #region Fields

        private List<Discipline> disciplines;

        #endregion

        #region Constructors

        public Teacher(string name) : base(name)
        {
            disciplines = new List<Discipline>();
        }

        public Teacher(string name, List<Discipline> disciplines) : this(name)
        {
            this.disciplines = disciplines;
        }

        #endregion

        #region Public Methods

        public void AddDiscipline(Discipline d)
        {
            this.disciplines.Add(d);
        }

        public void RemoveDiscipline(Discipline d)
        {
            this.disciplines.Remove(d);
        }

        public Discipline GetDisciplineByName(string name)
        {
            return this.disciplines.FirstOrDefault(discipline => discipline.Name == name);
        }

        #endregion
    }
}