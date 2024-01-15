using AmazingLibraryManager.BooksCatalog.Core.Entities;

namespace AmazingLibraryManager.BooksCatalog.UnitTests.Core.Entites
{
    public class BookTests
    {
        [Fact(DisplayName = "ValidBook_CreateBook_ReturnValidBook")]
        public void ValidBook_NewBookExecuted_ReturnValidBook() 
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

        [Fact(DisplayName = "CreateBook_WithNullTitle_ReturnArgumentException")]
        public void CreateBook_WithNullTitle_ReturnArgumentException() 
        {
            Action action = () => new Book(null, "Test Sub Title", "Test Author", DateTime.Now);

            Assert.Throws<ArgumentException>(action);
        }   
            
        [Fact(DisplayName = "CreateBook_WithNullSubTitle_ReturnArgumentException")]
        public void CreateBook_WithNullSubTitle_ReturnArgumentException() 
        {
            Action action = () => new Book("Test", null, "Test Author", DateTime.Now);

            Assert.Throws<ArgumentException>(action);
        }   

        [Fact(DisplayName = "CreateBook_WithEmptyAuthor_ReturnArgumentException")]
        public void CreateBook_WithEmptyAuthor_ReturnArgumentException() 
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
            Action action = () => new Book("Test", "T", "Test Author", DateTime.Now);

            Assert.Throws<ArgumentException>(action);
        }   
    }
}