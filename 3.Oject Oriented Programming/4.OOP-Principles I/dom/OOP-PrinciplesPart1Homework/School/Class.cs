using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Class : ICommentable
    {
        #region Fields

        private List<string> comments;
        private string id;
        private Dictionary<int, Student> students;
        private List<Teacher> teachers;

        #endregion

        #region Constructors

        public Class(string id, List<Student> students, List<Teacher> teachers, List<string> comments)
        {
            this.comments = new List<string>();
            this.students = new Dictionary<int, Student>();
            this.teachers = new List<Teacher>();
            this.Students = students;
            this.teachers = teachers;
            this.comments = comments;
            this.Id = id;
        }

        public Class(string id, List<Student> students, List<Teacher> teachers)
            : this(id, students, teachers, new List<string>())
        {
        }

        #endregion

        #region Properties

        private List<Student> Students
        {
            set
            {
                foreach (var student in value)
                {
                    AddStudent(student);
                }
            }
        }

        public string Id
        {
            get { return id; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("identifier cannot be null or empty");
                }
                id = value;
            }
        }

        #endregion

        #region Public Methods

        public void AddStudent(Student student)
        {
            try
            {
                this.students.Add(student.Id, student);
            }
            catch (Exception)
            {
                throw new ArgumentException("student IDs must be unique");
            }
        }

        public Student GetStudentByID(int ID)
        {
            return this.students.FirstOrDefault(x => x.Key == ID).Value;
        }

        public Teacher GetTeacherByName(string name)
        {
            return this.teachers.FirstOrDefault(x => x.Name == name);
        }

        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }

        public void RemoveTeacherByName(string Name)
        {
            for (int i = 0; i < this.teachers.Count; i++)
            {
                if (teachers[i].Name.Equals(Name))
                {
                    this.teachers.RemoveAt(i);
                    return;
                }
            }
        }

        public bool RemoveStudentByID(int ID)
        {
            return this.students.Remove(ID);
        }

        public void ValidateStudentEntries()
        {
            foreach (var student in this.students)
            {
                if (student.Key != student.Value.Id)
                {
                    if (students.ContainsKey(student.Value.Id))
                    {
                        Console.WriteLine(
                            "ID could not be changed because there already exists student with the specified ID");
                        student.Value.Id = student.Key;
                        return;
                    }
                    Student temp = student.Value;
                    students.Remove(student.Key);
                    students.Add(student.Value.Id, temp);
                    return;
                }
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