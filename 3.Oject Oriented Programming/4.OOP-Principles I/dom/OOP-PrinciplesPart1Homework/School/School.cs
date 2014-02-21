using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class School
    {
        #region Fields

        private Dictionary<string, Class> classes;

        #endregion

        #region Constructors

        public School(List<Class> classes) : this()
        {
            this.Classes = classes;
        }

        public School()
        {
            classes = new Dictionary<string, Class>();
        }

        #endregion

        #region Properties

        private List<Class> Classes
        {
            set
            {
                foreach (var c in value)
                {
                    try
                    {
                        AddClass(c);
                    }
                    catch (Exception)
                    {
                        throw new ArgumentException("Class IDs must be unique");
                    }
                }
            }
        }

        #endregion

        #region Public Methods

        public List<string> GetClassNames()
        {
            return this.classes.Keys.ToList();
        }

        public Class GetClassById(string classID)
        {
            return this.classes.FirstOrDefault(x => x.Key == classID).Value;
        }

        public void AddClass(Class c)
        {
            this.classes.Add(c.Id, c);
        }

        public bool RemoveClass(string classID)
        {
            return this.classes.Remove(classID);
        }

        #endregion
    }
}