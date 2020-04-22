using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        public string Name;

        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public Statistics GetStatistics()
        {
            return new Statistics()
            {
                Average = GetMean(),
                High = GetHighest(),
                Low = GetLowest(),
            };
        }

        public void AddGrade(double grade)
        {
            if (grade <= 0 || grade > 100) return;
            grades.Add(grade);
        }

        public double GetHighest()
        {
            return grades.Max();
        }

        public double GetLowest()
        {
            return grades.Min();
        }

        public double GetMean()
        {
            return grades.Sum() / grades.Count;
        }
    }
}
