using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectShared.Services.BookService;
using ProjectShared.BookStore;
using CommunityToolkit.Mvvm.Input;

namespace MyMauiApp.ViewModels
{

    [QueryProperty(nameof(Book), nameof(Book))]
    [QueryProperty(nameof(BooksViewModel), nameof(BooksViewModel))]

    public partial class SaveBookViewModel : ObservableObject
    {

        private readonly IBookService _bookService;
        [ObservableProperty]
        private BooksViewModel _booksViewModel;

        public SaveBookViewModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        [ObservableProperty]
        Book book;


        public async Task CreateBook()
        {
            var newBook = new Book()
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
            };

            var result = await _bookService.CreateBookAsync(newBook);
            if (result.Success)
                await _booksViewModel.GetBooks();
        }

        public async Task UpdateBook()
        {
            var bookToUpdate = new Book()
            {
                Id = book.Id,
                Author = book.Author,
                Title = book.Title,
                Description = book.Description
            };

            await _bookService.UpdateBookAsync(bookToUpdate);
            await _booksViewModel.GetBooks();
        }


        [RelayCommand]
        public async Task Save()
        {
            if (book.Id == 0)
            {
                CreateBook();
                await Shell.Current.GoToAsync("../", true);

            }
            else
            {
                UpdateBook();
                await Shell.Current.GoToAsync("../", true);
            }

        }
    }
}
