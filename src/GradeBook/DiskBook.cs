using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public override event GradeAddedDelegate GradeAdded;

        public DiskBook(string name) : base(name)
        {
        }

        public override void AddGrade(double grade)
        {
            Console.WriteLine("Add to file..");
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            throw new System.NotImplementedException();
        }
    }
}
