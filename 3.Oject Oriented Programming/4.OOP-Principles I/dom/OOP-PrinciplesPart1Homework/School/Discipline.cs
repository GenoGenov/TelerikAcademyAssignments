using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Discipline : ICommentable
    {
        #region Fields

        private List<string> comments;

        private string name;

        private int numOfExercises;

        private int numOfLecturers;

        #endregion

        #region Constructors

        public Discipline(List<string> comments, string name, int numOfExercises, int numOfLecturers)
        {
            this.comments = comments;
            this.Name = name;
            this.NumOfExercises = numOfExercises;
            this.NumOfLecturers = numOfLecturers;
        }

        public Discipline(string name, int numOfExercises, int numOfLecturers)
            : this(new List<string>(), name, numOfExercises, numOfLecturers)
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

        public int NumOfExercises
        {
            get { return numOfExercises; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("number of exercises cannot be less than 1");
                }
                numOfExercises = value;
            }
        }

        public int NumOfLecturers
        {
            get { return numOfLecturers; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("number of lecturers cannot be less than 1");
                }
                numOfLecturers = value;
            }
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
    }
}