using AmazingLibraryManager.BooksCatalog.Core.Entities;

namespace AmazingLibraryManager.BooksCatalog.UnitTests.Core.Entites
{
    public class BookTests
    {
        [Fact(DisplayName = "CreateBook_Executed_ReturnBook")]
        public void CreateBook_Executed_ReturnBook() 
        {
            // Arrange
            var title = "Test Title";
            var subTitle = "SubTitle Test";
            var author = "Author Test";
            var publishDate = DateTime.Now;

            // Act
            var book = new Book(title, subTitle, author, publishDate);

            // Assert
            Assert.NotNull(book);
            Assert.Equal(title, book.Title);
            Assert.Equal(subTitle, book.SubTitle);
            Assert.Equal(author, book.Author);
            Assert.Equal(publishDate, book.PublishDate);
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