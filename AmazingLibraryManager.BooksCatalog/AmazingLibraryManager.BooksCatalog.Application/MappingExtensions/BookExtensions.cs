using AmazingLibraryManager.BooksCatalog.Application.InputModels;
using AmazingLibraryManager.BooksCatalog.Application.ViewModels;
using AmazingLibraryManager.BooksCatalog.Core.Entities;

namespace AmazingLibraryManager.BooksCatalog.Application.MappingExtensions
{
    public static class BookExtensions
    {
        public static BookViewModel ToBookViewModel(this Book book) 
        {
            return new BookViewModel(book);
        }
    }
}