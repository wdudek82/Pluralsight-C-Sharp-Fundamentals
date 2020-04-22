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

            // When
            var book1 = GetBook(name1);
            var book2 = GetBook(name2);

            // Then
            Assert.Equal(name1, book1.Name);
            Assert.Equal(name2, book2.Name);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            // Given
            const string name1 = "Book 1";

            // When
            var book1 = GetBook(name1);
            var book2 = book1;

            // Then
            Assert.Same(book1,  book2);
        }

        private static Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
