using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void GetBookReturnDifferentObjects()
        {

            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("Book1", book1.Name);
           
        }

        private void SetName(Book book, string name)
        {

            book.Name = name;
        }
       
        
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {

            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same( book1, book2);
            Assert.True(Object.ReferenceEquals(book1,book2));
        }


        Book GetBook(String name)
        {

            return new Book(name);

        }
    }
}
