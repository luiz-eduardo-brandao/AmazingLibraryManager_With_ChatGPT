using System.Runtime.Serialization;
using AmazingLibraryManager.BooksCatalog.Application.InputModels;
using AmazingLibraryManager.BooksCatalog.Application.Services;
using AmazingLibraryManager.BooksCatalog.Core.Entities;
using AmazingLibraryManager.BooksCatalog.Infrastructure.Persistence;


namespace AmazingLibraryManager.BooksCatalog.UnitTests.Application.Services
{
    public class BookServiceTests
    {
        [Fact(DisplayName = "UpdateBook_Executed_ReturnBookUpdated")]
        public async void UpdateBook_Executed_ReturnBookUpdated() 
        {
            // Arrange
            var title = "first title";
            var subTitle = "first subtitle";
            var author = "first author";
            var publishDate = DateTime.Now;
            
            var insertBookInputModel = new InsertBookInputModel{
                Title = title,
                SubTitle = subTitle,
                Author = author,
                PublishDate = publishDate
            };

            var newTitle = "new title";
            var newSubTitle = "new subtitle";
            var newAuthor = "new author";
            var newPublishDate = DateTime.Now.AddDays(2);

            var updateBookInputModel = new InsertBookInputModel{
                Title = newTitle,
                SubTitle = newSubTitle,
                Author = newAuthor,
                PublishDate = newPublishDate
            };

            var repository = new BookRepository();
            var service = new BookService(repository);

            // Act
            var resultAdd = await service.AddBook(insertBookInputModel);

            var firstBook = service.GetById(resultAdd.Id);

            updateBookInputModel.Id = resultAdd.Id;

            var resultUpdate = await service.UpdateBook(updateBookInputModel);

            var secondBook = service.GetById(resultUpdate.Id);

            // Assert
            Assert.NotEqual(firstBook, secondBook);
        }

        [Fact(DisplayName = "CreateThreeBooks_Executed_ReturnThreeBooks")]
        public async void CreateThreeBooks_Executed_ReturnThreeBooks() 
        {   
            // Arrange
            var books = new List<Book>
            {
                new Book("Test 1", "Desc 1", "Test 1", DateTime.Now),
                new Book("Test 2", "Desc 2", "Test 2", DateTime.Now),
                new Book("Test 3", "Desc 3", "Test 3", DateTime.Now),
            };

            var repository = new BookRepository();
            var service = new BookService(repository);

            // Act
            foreach (var book in books) await repository.AddBookAsync(book);
            
            var result = await service.GetAllBooks();
            
            // Assert
            Assert.Equal(books, result);
        }
    }
}