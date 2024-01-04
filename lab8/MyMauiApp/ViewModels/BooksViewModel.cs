﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ProjectShared.Services.BookService;
using ProjectShared.BookStore;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using ProjectShared.Services.AuthService;
using System.IdentityModel.Tokens.Jwt;

namespace MyMauiApp.ViewModels
{
    public partial class BooksViewModel : ObservableObject
    {

        private readonly IBookService _bookService;
        private readonly IAuthService _authService;

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

        [ObservableProperty]
        bool isUserAuthenticated;
        [ObservableProperty]
        bool isUserNotAuthenticated;

        public BooksViewModel(IBookService bookService, IAuthService authService)
        {
            _bookService = bookService;
            _authService = authService;
            Books = new ObservableCollection<Book>();
            isUserAuthenticated = !string.IsNullOrEmpty(SecureStorage.GetAsync("AuthToken").Result);
            isUserNotAuthenticated = !isUserAuthenticated;
            Init();
        }

        public async void Init()
        {
            await GetBooks();
        }

        public async Task GetBooks()
        {
            Books.Clear();

            var booksResult = await _bookService.GetBooksAsync(CurrentPage, PageSize);
            if (booksResult.Success)
            {
                foreach (var book in booksResult.Data.Data)
                {
                    Books.Add(book);
                }
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

        [RelayCommand]
        public async Task CreateBook()
        {
            string role = await GetUserRoleAsync();
            if (!"Admin".Equals(role))
            {
                await Shell.Current.GoToAsync(nameof(ErrorView), true);
            } else
            {
                await Shell.Current.GoToAsync(nameof(SaveBookView), true, new Dictionary<string, object>
                {
                    {"Book", new Book()},
                    {nameof(BooksViewModel), this}
                });
            }
            
        }

        [RelayCommand]
        public async Task EditBook(Book book)
        {
            string role = await GetUserRoleAsync();
            if (!"Admin".Equals(role))
            {
                await Shell.Current.GoToAsync(nameof(ErrorView), true);
            } else
            {
                await Shell.Current.GoToAsync(nameof(SaveBookView), true, new Dictionary<string, object>
                {
                    {"Book", book},
                    {nameof(BooksViewModel), this}
                });
            }
            
        }

        [RelayCommand]
        public async Task DeleteBook(Book book)
        {
            string role = await GetUserRoleAsync();
            if (!"Admin".Equals(role))
            {
                await Shell.Current.GoToAsync(nameof(ErrorView), true);
            } else
            {
                await _bookService.DeleteBookAsync(book.Id);
                await GetBooks();
            }
            
        }

        [RelayCommand]
        public async Task ShowDetails(Book book)
        {
            string role = await GetUserRoleAsync();
            if("".Equals(role))
            {
                await Shell.Current.GoToAsync(nameof(ErrorView), true);
            } else
            {
                await Shell.Current.GoToAsync(nameof(ShowDetailsView), true, new Dictionary<string, object>
                {
                    {"Book", book},
                    {nameof(BooksViewModel), this}
                });
            }
            
        }

        [RelayCommand]
        public async Task Login()
        {
            await Shell.Current.GoToAsync(nameof(LoginView), true, new Dictionary<string, object>
            {
                {nameof(BooksViewModel), this}
            });
        }

        [RelayCommand]
        public async Task Register()
        {
            await Shell.Current.GoToAsync(nameof(RegisterView), true);
        }

        [RelayCommand]
        public async Task Logout()
        {
            SecureStorage.Remove("AuthToken");

            SetProperty(ref isUserAuthenticated, false, nameof(IsUserAuthenticated));
            SetProperty(ref isUserNotAuthenticated, true, nameof(IsUserNotAuthenticated));
        }

        private async Task<string> GetUserRoleAsync()
        {
            string jwtToken = await SecureStorage.GetAsync("AuthToken");

            if (string.IsNullOrEmpty(jwtToken))
            {
                return ""; // or throw an exception or handle the case accordingly
            }

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken) as JwtSecurityToken;

            // Extract the user role from the JWT claims
            string userRole = jsonToken?.Claims
                .Where(claim => claim.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role") // Adjust the claim type based on your JWT structure
                .Select(claim => claim.Value)
                .FirstOrDefault();

            return userRole ?? ""; // Return an empty string if userRole is null
        }

    }
}
