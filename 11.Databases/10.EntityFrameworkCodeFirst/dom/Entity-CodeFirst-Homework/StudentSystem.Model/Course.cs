﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Model
{

    public class Course
    {
        private ICollection<Material> materials;

        private ICollection<Student> students;

        private ICollection<Homework> homeworks;
        public Course()
        {
            this.materials=new HashSet<Material>();
            this.students=new HashSet<Student>();
        }
        public int CourseId { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Material> Materials
        {
            get
            {
                return this.materials;
            }
            set
            {
                this.materials = value;
            }
        }

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get
            {
                return this.homeworks;
            }
            set
            {
                this.homeworks = value;
            }
        }
    }
}
