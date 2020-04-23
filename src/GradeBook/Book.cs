using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    public abstract class Book : NameObject, IBook
    {
        protected readonly List<double> Grades;

        public abstract event GradeAddedDelegate GradeAdded;

        protected Book(string name) : base(name)
        {
            Grades = new List<double>();
        }

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();

        protected virtual double GetHighest()
        {
            if (Grades.Count == 0) return 0;
            return Grades.Max();
        }

        protected virtual double GetLowest()
        {
            if (Grades.Count == 0) return 0;
            return Grades.Min();
        }

        protected virtual double GetMean()
        {
            if (Grades.Count == 0) return 0;
            return Grades.Sum() / Grades.Count;
        }

    }
}
