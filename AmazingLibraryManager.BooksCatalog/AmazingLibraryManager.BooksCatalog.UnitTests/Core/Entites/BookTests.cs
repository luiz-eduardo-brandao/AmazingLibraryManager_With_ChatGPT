using AmazingLibraryManager.BooksCatalog.Core.Entities;

namespace AmazingLibraryManager.BooksCatalog.UnitTests.Core.Entites
{
    public class BookTests
    {
        [Fact(DisplayName = "CreateBook_WithAllValidParameters_ResultSuccess")]
        public void CreateBook_WithAllValidParameters_ReturnValidBook() 
        {
            var book = new Book("Harry Potter", "E a Ordem da Fênix", "J.K Rolling", DateTime.Now);

            Assert.NotNull(book);

            Assert.NotNull(book.Title);
            Assert.NotEmpty(book.Title);

            Assert.NotNull(book.SubTitle);
            Assert.NotEmpty(book.SubTitle);

            Assert.NotNull(book.Author);
            Assert.NotEmpty(book.Author);

            Assert.NotNull(book.PublishDate);
            Assert.NotEmpty(book.PublishDate.ToString());
        }   

        [Fact(DisplayName = "CreateBook_WithoutTitle_ReturnArgumentException")]
        public void CreateBook_WithoutTitle_ReturnArgumentException() 
        {
            Action action = () => new Book(null, "E a Ordem da Fênix", "J.K Rolling", DateTime.Now);

            Assert.Throws<ArgumentException>(action);
        }   
            
        [Fact(DisplayName = "CreateBook_WithoutSubTitle_ReturnArgumentException")]
        public void CreateBook_WithoutSubTitle_ReturnArgumentException() 
        {
            Action action = () => new Book("Test", null, "J.K Rolling", DateTime.Now);

            Assert.Throws<ArgumentException>(action);
        }   

        [Fact(DisplayName = "CreateBook_WithoutAuthor_ReturnArgumentException")]
        public void CreateBook_WithoutAuthor_ReturnArgumentException() 
        {
            Action action = () => new Book("Test", "SubTitle", "", DateTime.Now);

            Assert.Throws<ArgumentException>(action);
        }   

        [Fact(DisplayName = "CreateBook_WithShortTitle_ReturnArgumentException")]
        public void CreateBook_WithShortTitle_ReturnArgumentException() 
        {
            Action action = () => new Book("T", "SubTitle", "", DateTime.Now);

            Assert.Throws<ArgumentException>(action);
        }   

        [Fact(DisplayName = "CreateBook_WithShortSubTitle_ReturnArgumentException")]
        public void CreateBook_WithShortSubTitle_ReturnArgumentException() 
        {
            Action action = () => new Book("Test", "T", "J.K Rolling", DateTime.Now);

            Assert.Throws<ArgumentException>(action);
        }   
    }
}