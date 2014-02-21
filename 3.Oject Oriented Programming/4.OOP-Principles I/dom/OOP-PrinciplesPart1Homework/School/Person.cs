using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public abstract class Person : ICommentable
    {
        #region Fields

        private List<string> comments;

        private string name;

        #endregion

        #region Constructors

        protected Person(string name, List<string> comments)
        {
            this.comments = comments;
            this.Name = name;
        }

        protected Person(string name) : this(name, new List<string>())
        {
        }

        #endregion

        #region Implementation of ICommentable

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }

        public void RemoveComment(int index)
        {
            this.comments.RemoveAt(index);
        }

        public void ClearComments()
        {
            this.comments.Clear();
        }

        public void PrintComments()
        {
            foreach (var comment in this.comments)
            {
                Console.WriteLine(comment);
            }
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
                    throw new ArgumentException("Name cannot be null or empty");
                }
                name = value;
            }
        }

        #endregion
    }
}