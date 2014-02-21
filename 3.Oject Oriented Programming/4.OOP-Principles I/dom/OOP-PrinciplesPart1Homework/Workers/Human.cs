using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    public abstract class Human
    {
        #region Fields

        protected string firstName;
        protected string lastName;

        #endregion

        #region Constructors

        public Human(string first, string last)
        {
            this.FirstName = first;
            this.LastName = last;
        }

        #endregion

        #region Properties

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("name cannot be null or empty");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("name cannot be null or empty");
                }
                lastName = value;
            }
        }

        #endregion
    }
}