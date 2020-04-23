namespace GradeBook
{
    public abstract class Book : NameObject
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);
    }
}
