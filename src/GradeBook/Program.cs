using System;

namespace GradeBook
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IBook book = new InMemoryBook("Scott's Grade Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"Book: {book.Name}");
            Console.WriteLine($"Average: {stats.Average:N1}");
            Console.WriteLine($"Highest grade: {stats.High}");
            Console.WriteLine($"Lowest grade: {stats.Low}");
            Console.WriteLine($"The letter is: {stats.Letter}");
        }

        private static void EnterGrades(IBook inMemoryBook)
        {
            do
            {
                Console.Write("> ");

                var input = Console.ReadLine();

                if (input.Equals("q")) break;

                try
                {
                    var newGrade = double.Parse(input);
                    inMemoryBook.AddGrade(newGrade);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (true);
        }

        private static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added.");
        }
    }
}
