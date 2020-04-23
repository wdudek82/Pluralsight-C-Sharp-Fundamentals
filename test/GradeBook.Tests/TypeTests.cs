using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        private int _count;

        private string ReturnLowerMessage(string message)
        {
            _count++;
            return message.ToLower();
        }

        private string ReturnMessage(string message)
        {
            _count++;
            return message;
        }

        private static string MakeUppercase(string s)
        {
            return s.ToUpper();
        }

        private static void SetInt(ref int x)
        {
            x = 4;
        }

        private static int GetInt3()
        {
            return 3;
        }

        private static InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }

        private static void SetName(InMemoryBook inMemoryBook, string name)
        {
            inMemoryBook.Name = name;
        }

        private static void GetBookSetName(InMemoryBook inMemoryBook, string name)
        {
            inMemoryBook = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            // Given
            const string name1 = "Book 1";
            const string name2 = "New Name";
            var book1 = GetBook(name1);

            // When
            SetName(book1, name2);

            // Then
            Assert.Equal(name2, book1.Name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            // Given
            const string name1 = "Book1";
            const string name2 = "New Name";
            var book1 = GetBook(name1);

            // When
            GetBookSetName(book1, name2);

            // Then
            Assert.Equal(name1, book1.Name);
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // Given
            const string name1 = "Book 1";
            const string name2 = "Book 2";
            var book1 = GetBook(name1);
            var book2 = GetBook(name2);

            // When

            // Then
            Assert.Equal(name1, book1.Name);
            Assert.Equal(name2, book2.Name);
        }

        [Fact]
        public void StringsBehaveLikeValueType()
        {
            const string name = "Scott";
            var upper = MakeUppercase(name);

            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
        }

        [Fact]
        public void Test1()
        {
            var x = GetInt3();
            SetInt(ref x);

            Assert.Equal(4, x);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            // Given
            const string name1 = "Book 1";
            var book1 = GetBook(name1);
            var book2 = book1;

            // When

            // Then
            Assert.Same(book1, book2);
        }

        [Fact]
        public void WriteLogDelegateConPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            // log = new WriteLogDelegate(ReturnMessage);
            log += ReturnMessage;
            log += ReturnLowerMessage;

            Assert.Equal(3, _count);
        }
    }
}
