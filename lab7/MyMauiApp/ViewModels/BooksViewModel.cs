using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ProjectShared.Services.BookService;
using ProjectShared.BookStore;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace MyMauiApp.ViewModels
{
    public partial class BooksViewModel : ObservableObject
    {

        private readonly IBookService _bookService;
        private readonly IConnectivity _connectivity;

        private ObservableCollection<Book> _books;
        private int _pageSize = 10;
        private int _currentPage = 1;

        public ObservableCollection<Book> Books
        {
            get => _books;
            set => SetProperty(ref _books, value, nameof(Books));
        }

        public int PageSize
        {
            get => _pageSize;
            set => SetProperty(ref _pageSize, value, nameof(PageSize));
        }

        public int CurrentPage
        {
            get => _currentPage;
            set => SetProperty(ref _currentPage, value, nameof(CurrentPage));
        }

        public BooksViewModel(IBookService bookService, IConnectivity connectivity)
        {
            _bookService = bookService;
            _connectivity = connectivity;
            Books = new ObservableCollection<Book>();
        }

        public async Task GetBooks()
        {
            Books.Clear();
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                //_messageDialogService.ShowMessage("Internet not available!");
                return;
            }

            var booksResult = await _bookService.GetBooksAsync(CurrentPage, PageSize);
            if (booksResult.Success)
            {
                foreach (var book in booksResult.Data.Data)
                {
                    Books.Add(book);
                }
            }
            else
            {
                //_messageDialogService.ShowMessage(productsResult.Message);
            }
        }

        [RelayCommand]
        public async Task LoadNextPage()
        {
            CurrentPage++;
            await GetBooks();
        }

        [RelayCommand]
        public async Task LoadPreviousPage()
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                await GetBooks();
            }
        }
    }
}
