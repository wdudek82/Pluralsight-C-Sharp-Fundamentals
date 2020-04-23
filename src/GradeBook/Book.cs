using System;

namespace GradeBook
{
    public abstract class Book : NameObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);

        public virtual Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }

        public virtual event GradeAddedDelegate GradeAdded;
    }
}
