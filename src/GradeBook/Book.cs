using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        public string name;

        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = GetMean();
            result.High = GetHighest();
            result.Low = GetLowest();

            return result;
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
