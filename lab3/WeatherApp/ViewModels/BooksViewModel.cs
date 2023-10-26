using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Shared.Services.BookService;
using Shared.BookStore;

namespace WeatherApp.ViewModels
{
    public partial class BooksViewModel : ObservableObject
    {
        private readonly IBookService _bookService;

        public ObservableCollection<Book> Books { get; set; }

        public BooksViewModel(IBookService bookService)
        {
            _bookService = bookService;
            Books = new ObservableCollection<Book>();
        }

        public async void GetProducts()
        {
            var productsResult = await _bookService.GetBooksAsync();
            if (productsResult.Success)
            {
                foreach (var p in productsResult.Data)
                {
                    Books.Add(p);
                }
            }
        }

        public async void DeleteProduct()
        {
            
        }

    }
}
