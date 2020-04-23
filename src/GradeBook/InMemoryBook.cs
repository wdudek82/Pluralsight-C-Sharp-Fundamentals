using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public void AddGrade(char grade)
        {
            switch (grade)
            {
                case 'A':
                case 'a':
                    AddGrade(90);
                    break;
                case 'B':
                case 'b':
                    AddGrade(80);
                    break;
                case 'C':
                case 'c':
                    AddGrade(70);
                    break;
                case 'D':
                case 'd':
                    AddGrade(60);
                    break;
                case 'E':
                case 'e':
                    AddGrade(50);
                    break;
                case 'F':
                case 'f':
                    AddGrade(40);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public override void AddGrade(double grade)
        {
            if (grade < 0 || grade > 100)
            {
                Console.WriteLine("Invalid value");
                return;
            }

            ;
            Grades.Add(grade);

            if (GradeAdded != null) GradeAdded(this, new EventArgs());
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics
            {
                Average = GetMean(),
                High = GetHighest(),
                Low = GetLowest()
            };

            result.Letter = result.Average switch
            {
                var d when d >= 90.0 => 'A',
                var d when d >= 80.0 => 'B',
                var d when d >= 70.0 => 'C',
                var d when d >= 60.0 => 'D',
                var d when d >= 50.0 => 'E',
                _ => 'F'
            };

            // switch (result.Average)
            // {
            //     case var d when d >= 90.0:
            //         result.Letter = 'A';
            //         break;
            //     case var d when d >= 80.0:
            //         result.Letter = 'B';
            //         break;
            //     case var d when d >= 70.0:
            //         result.Letter = 'C';
            //         break;
            //     case var d when d >= 60.0:
            //         result.Letter = 'D';
            //         break;
            //     case var d when d >= 50.0:
            //         result.Letter = 'E';
            //         break;
            //     default:
            //         result.Letter = 'F';
            //         break;
            // }

            return result;
        }
    }
}
