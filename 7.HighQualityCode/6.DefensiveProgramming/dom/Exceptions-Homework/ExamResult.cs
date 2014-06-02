﻿namespace Exceptions
{
    using System;

    public class ExamResult
    {
        private int grade;

        private int minGrade;

        private int maxGrade;

        private string comments;

        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("the grade cannot be less than zero!");
                }

                this.grade = value;
            }
        }

        public int MinGrade
        {
            get
            {
                return this.minGrade;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The minimum grade cannot be less than zero!");
                }

                this.minGrade = value;
            }
        }

        public int MaxGrade
        {
            get
            {
                return this.maxGrade;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The maximum grade cannot be less than zero!");
                }

                this.maxGrade = value;
            }
        }

        public string Comments
        {
            get
            {
                return new string(this.comments.ToCharArray());
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The comments cannot be null or empty!");
                }

                this.comments = value;
            }
        }
    }
}