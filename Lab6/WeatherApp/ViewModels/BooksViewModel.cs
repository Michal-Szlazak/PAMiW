using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ProjectShared.Services.BookService;
using ProjectShared.BookStore;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using WeatherApp.error;

namespace WeatherApp.ViewModels
{
    public partial class BooksViewModel : ObservableObject
    {
        private readonly IBookService _bookService;
        private readonly BookDetailsView _bookDetailsView;

        public ObservableCollection<Book> Books { get; set; }

        [ObservableProperty]
        public Book selectedBook;
        /*
        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook= value;
                OnPropertyChanged();
            }
        }*/

        public BooksViewModel(IBookService bookService, BookDetailsView bookDetailsView)
        {
            _bookService = bookService;
            _bookDetailsView = bookDetailsView;
            Books = new ObservableCollection<Book>();
        }

        public async Task GetBooks()
        {
            
            var BooksResult = await _bookService.GetBooksAsync(1, 1);
            if (BooksResult.Success)
            {
                Books.Clear();
                foreach (var p in BooksResult.Data.Data)
                {
                    Books.Add(p);
                }
            }
        }

        public async Task CreateBook()
        {
            var newBook = new Book()
            {
                Title = selectedBook.Title,
                Description = selectedBook.Description,
                Author = selectedBook.Author,
            };

            var result = await _bookService.CreateBookAsync(newBook);
            if (result.Success)
                await GetBooks();
            else
                ErrorMessage.showMessage(result.Message);
        }

        public async Task UpdateBook()
        {
            var updatedBook = new Book()
            {
                Id = selectedBook.Id,
                Title = selectedBook.Title,
                Description = selectedBook.Description,
                Author = selectedBook.Author,
            };

            var result = await _bookService.UpdateBookAsync(updatedBook);
            if (result.Success)
                await GetBooks();
            else
                ErrorMessage.showMessage(result.Message);
        }

        public async Task DeleteBook()
        {
            var result = await _bookService.DeleteBookAsync(selectedBook.Id);
            if (result.Success)
                await GetBooks();
            else
                ErrorMessage.showMessage(result.Message);
        }

        [RelayCommand]
        public async Task ShowDetails(Book Book)
        {
            _bookDetailsView.Show();
            _bookDetailsView.DataContext = this;
            selectedBook = Book;
        }


        [RelayCommand]
        public async Task Save()
        {
            if (selectedBook.Id == 0)
            {
                CreateBook();
            }
            else
            {
                UpdateBook();
            }

        }

        [RelayCommand]
        public async Task Delete()
        {
            DeleteBook();
        }

        [RelayCommand]
        public async Task New()
        {
            _bookDetailsView.Show();
            _bookDetailsView.DataContext = this;
            SelectedBook = new Book();
        }
    }
}
