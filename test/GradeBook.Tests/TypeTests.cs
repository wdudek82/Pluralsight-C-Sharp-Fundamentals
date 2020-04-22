using System.Transactions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
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
        public void TwoVarsCanReferenceSameObject()
        {
            // Given
            const string name1 = "Book 1";
            var book1 = GetBook(name1);
            var book2 = book1;

            // When

            // Then
            Assert.Same(book1,  book2);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            // Given
            const string name1 = "Book 1";
            const string name2 = "New Name";
            var book1 = GetBook(name1);
            var book2 = book1;

            // When
            SetName(book1, name2);

            // Then
            // Assert.Same(book1, book2);
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
        public void Test1()
        {
            var x = GetInt3();
            SetInt(ref x);

            Assert.Equal(4, x);
        }

        private static void SetInt(ref int x)
        {
            x = 4;
        }

        private static int GetInt3()
        {
            return 3;
        }

        private static Book GetBook(string name)
        {
            return new Book(name);
        }

        private static void SetName(Book book, string name)
        {
            book.Name = name;
        }

        private static void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }
    }
}
