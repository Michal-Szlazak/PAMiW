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
        private readonly IConnectivity _connectivity;
        private MessageBox _messageBox;
        [ObservableProperty]
        private BooksViewModel _booksViewModel;
        [ObservableProperty]
        bool isLoading = false;

        public SaveBookViewModel(IBookService bookService, IConnectivity connectivity)
        {
            _bookService = bookService;
            _connectivity = connectivity;
            _messageBox = new MessageBox();
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
            IsLoading = true;

            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                _messageBox.ShowMessage("Internet not available!");
                IsLoading = false;
                return;
            }
            string token = Task.Run(() => SecureStorage.GetAsync("AuthToken")).GetAwaiter().GetResult();

            var result = await _bookService.CreateBookAsync(newBook, token);
            if (result.Success)
                await BooksViewModel.GetBooks();
            else
            {
                _messageBox.ShowMessage("Incorrect input! Book wasn't created.");
            }

            IsLoading = false;
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
            IsLoading = true;

            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                _messageBox.ShowMessage("Internet not available!");
                IsLoading = false;
                return;
            }
            string token = Task.Run(() => SecureStorage.GetAsync("AuthToken")).GetAwaiter().GetResult();
            await _bookService.UpdateBookAsync(bookToUpdate, token);
            await BooksViewModel.GetBooks();
            IsLoading = false;
        }


        [RelayCommand]
        public async Task Save()
        {
            if (Book.Id == 0)
            {
                await CreateBook();
                await Shell.Current.GoToAsync("../", true);

            }
            else
            {
                await UpdateBook();
                await Shell.Current.GoToAsync("../", true);
            }

        }
    }
}
