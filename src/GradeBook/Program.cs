using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Scott's Grade Book");
            // book.AddGrade(89.1);
            // book.AddGrade(12.7);
            // book.AddGrade(10.3);
            // book.AddGrade(6.11);

            do
            {
                Console.Write("> ");

                var input = Console.ReadLine();

                if (input.Equals("q"))
                {
                    break;
                }

                try
                {
                    var newGrade = double.Parse(input);
                    book.AddGrade(newGrade);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (true);

            var stats = book.GetStatistics();

            Console.WriteLine($"Book: {book.Name}");
            Console.WriteLine($"Average: {stats.Average:N1}");
            Console.WriteLine($"Highest grade: {stats.High}");
            Console.WriteLine($"Lowest grade: {stats.Low}");
            Console.WriteLine($"The letter is: {stats.Letter}");
        }
    }
}
