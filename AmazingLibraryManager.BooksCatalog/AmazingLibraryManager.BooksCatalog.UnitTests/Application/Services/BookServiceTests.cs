using AmazingLibraryManager.BooksCatalog.Application.InputModels;
using AmazingLibraryManager.BooksCatalog.Application.Services;
using AmazingLibraryManager.BooksCatalog.Core.Entities;
using AmazingLibraryManager.BooksCatalog.Core.Repositories;
using AutoFixture;
using Moq;
using Shouldly;


namespace AmazingLibraryManager.BooksCatalog.UnitTests.Application.Services
{
    public class BookServiceTests
    {
        [Fact(DisplayName = "ValidBook_AddIsCalled_ReturnValidBookViewModel")]
        public async void ValidBook_AddIsCalled_ReturnValidBookViewModel() 
        {
            // Arrange
            var insertBookInputModel = new Fixture().Create<InsertBookInputModel>();

            var bookRepositoryMock = new Mock<IBookRepository>();

            var bookService = new BookService(bookRepositoryMock.Object);

            // Act
            var result = await bookService.AddBook(insertBookInputModel);

            // Assert

            // xUnit
            Assert.Equal(insertBookInputModel.Title, result.Title);
            Assert.Equal(insertBookInputModel.SubTitle, result.SubTitle);
            Assert.Equal(insertBookInputModel.Author, result.Author);
            Assert.Equal(insertBookInputModel.PublishDate, result.PublishDate);

            // Shoudly
            result.Title.ShouldBe(insertBookInputModel.Title);
            result.SubTitle.ShouldBe(insertBookInputModel.SubTitle);
            result.Author.ShouldBe(insertBookInputModel.Author);
            result.PublishDate.ShouldBe(insertBookInputModel.PublishDate);

            bookRepositoryMock.Verify(br => br.AddBookAsync(It.IsAny<Book>()), Times.Once);
        }

        [Fact(DisplayName = "UpdateBookAuthor_UpdateIsCalled_ReturnNewValidBookViewModel")]
        public async void UpdateBookAuthor_UpdateIsCalled_ReturnNewValidBookViewModel() 
        {
            // Arrange
            var addBookInputModel = new Fixture().Create<InsertBookInputModel>();
            var updateBookInputModel = addBookInputModel;

            var bookRepositoryMock = new Mock<IBookRepository>();

            var bookService = new BookService(bookRepositoryMock.Object);

            // Act
            var addResult = await bookService.AddBook(addBookInputModel);

            updateBookInputModel.Id = addResult.Id;
            updateBookInputModel.Author = "update author";

            var updateResult = await bookService.UpdateBook(updateBookInputModel);

            // Assert
            Assert.Equal(addResult.Title, updateResult.Title);
            Assert.Equal(addResult.SubTitle, updateResult.SubTitle);
            Assert.NotEqual(addResult.Author, updateResult.Author);
            Assert.Equal(addResult.PublishDate, updateResult.PublishDate);

            bookRepositoryMock.Verify(br => br.AddBookAsync(It.IsAny<Book>()), Times.Once);
            bookRepositoryMock.Verify(br => br.UpdateBookAsync(It.IsAny<Book>()), Times.Once);
        }

        [Fact(DisplayName = "DeleteNonExistentBook_DeleteIsCalled_ThrowException")]
        public void DeleteNonExistentBook_DeleteIsCalled_ThrowException() 
        {
            // Arrange
            Guid bookId = Guid.NewGuid();

            var bookRepositoryMock = new Mock<IBookRepository>();

            var bookService = new BookService(bookRepositoryMock.Object);

            // Act + Assert
            // var exception = Assert.ThrowsAsync<NullReferenceException>(() => bookService.DeleteBook(bookId));

            // Assert.Equal("There's no Book with this Id.", exception.Result.Message);

            Should.ThrowAsync<NullReferenceException>(
                () => bookService.DeleteBook(bookId))
                .Result.Message.ShouldBe("There's no Book with this Id.");
        }
    }
}