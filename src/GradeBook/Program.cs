using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Scott's Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(12.7);
            book.AddGrade(10.3);
            book.AddGrade(6.11);

            var stats = book.GetStatistics();

            Console.WriteLine($"Book: {book.name}");
            Console.WriteLine($"Average: {stats.Average:N1}");
            Console.WriteLine($"Highest grade: {stats.High}");
            Console.WriteLine($"Lowest grade: {stats.Low}");

            var list = new List<int>() {1, 2, 3};
            list[0] = 100;

            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
