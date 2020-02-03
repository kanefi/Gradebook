using System;
using Xunit;


namespace Gradebook.Tests
{
    public class TypeTests
   { 
   
   [Fact]
    public void ValueTypesAlsoPassByValue()
    {
        var x = GetInt();
        SetInt(ref x);

        Assert.Equal(42, x);
    }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int GetInt()
    {
        return 3;
    }

    [Fact]
        public void CSharpCanPassByRef()            // Rare to actually use Ref. Alternative is Out keyword
                {
            var book1 = GetBook("Book 1");
            GetBookSetName(out book1, "New Name"); // ** Also need keyword Ref here (invoking method here)
            Assert.Equal("New Name", book1.Name);      // When you pass a variable to another method, you don't want that method to change the value of that variable. 
            
        }
        
        public void GetBookSetName(out Book book, string name) // ** Added keyword 'ref', tells compiler that this first parameter will be passed by reference to memory location
        {                                   // am I writing that value into the book1 value or am I just making changes to this local parameter.
            book = new Book(name);         // constructing a new book instance and setting name
        }

        [Fact]
        public void CSharpIsPassByValue()                    {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            
            Assert.Equal("Book 1", book1.Name);       
            
        }
        
        public void GetBookSetName(Book book, string name)
        {                                   
            book = new Book(name);
        }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [Fact]
        public void CanSetNameFromReference()            // Rename from Test1
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");
            
            Assert.Equal("New Name", book1.Name);
            
        }
        
        private void SetName(Book book, string name)
        {
            book.Name = name;        
        }

         public void StringsBehaveLikeValueTypes()
        {
            string name = "Scott";
            var upper = MakeUppercase(name);

            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()            // Rename from Test1
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()            // Rename from Test1
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;
            
            Assert.Same(book1, book2);          // Asserts that points to same reference, two objects are the same instance
            Assert.True(Object.ReferenceEquals(book1, book2));
        }
        Book GetBook(string name)              // Object to left of method is return type (e.g. void)
        {
            return new Book(name);
        }
    }
}
