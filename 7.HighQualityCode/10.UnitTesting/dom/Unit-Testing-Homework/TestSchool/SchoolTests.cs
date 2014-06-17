namespace TestSchool
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;
    using School;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatingSchoolWithNullNameShouldthrowException()
        {
            var school = new School(null, new List<Course>());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatingCourseWithNullNameShouldthrowException()
        {
            var course = new Course(null, new List<Student>());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatingStudentWithNullNameShouldthrowException()
        {
            var student = new Student(344, null);
        }

        [TestMethod]
        public void CreatingSchoolWithOneCoursesShouldReturnOne()
        {
            var school = new School(
                "school",
                new List<Course>()
                {
                    new Course(
                        "sss",
                        new List<Student>
                        {
                            new Student(
                                11111,
                                "ssss")
                        })
                });
            Assert.AreEqual(1, school.Courses.Count);
        }

        [TestMethod]
        public void CreatingCourseWithOneStudentsShouldReturnOne()
        {
            var course = new Course("sss", new List<Student>() { new Student(11111, "ppp") });
            Assert.AreEqual(1, course.Students.Count);
        }

        [TestMethod]
        public void CreatingStudentWithNumberShouldAssignItCorrectly()
        {
            var student = new Student(34444, "aaa");
            Assert.AreEqual(34444, student.Number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatingStudentWithNumberOutOfRangeShouldThrowException()
        {
            var student = new Student(344, "aaa");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddingCourseWithSameNameShouldThrowException()
        {
            var school = new School(
                "school",
                new List<Course>()
                {
                    new Course(
                        "alabala",
                        new List<Student>
                        {
                            new Student(
                                11111,
                                "alabala")
                        }),
                    new Course("alabala", new List<Student> { })
                });
        }

        [TestMethod]
        public void AddingStudentToCourseShouldincreaseItsStudentsCount()
        {
            var student = new Student(34444, "aaa");
            var school = new School("the school", new List<Course> { new Course("course", new List<Student>()) });
            school.AddStudentToCourse(student, "course");
            Assert.AreEqual(1, school.Courses.Single(x => x.Name == "course").Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddingStudentsWithSameNumbersShouldThrowException()
        {
            var school = new School(
                "school",
                new List<Course>()
                {
                    new Course(
                        "alabala",
                        new List<Student>
                        {
                            new Student(
                                11111,
                                "alabala")
                        }),
                    new Course(
                        "afafafaf",
                        new List<Student>
                        {
                            new Student(11111, "dddddd")
                        })
                });
        }
    }
}