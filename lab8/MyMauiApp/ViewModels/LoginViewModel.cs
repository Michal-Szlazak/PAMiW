using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectShared.Services.AuthService;
using ProjectShared.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMauiApp.ViewModels
{

    [QueryProperty(nameof(BooksViewModel), nameof(BooksViewModel))]
    public partial class LoginViewModel : ObservableObject
    {

        private readonly IAuthService _authService;
        private readonly IConnectivity _connectivity;
        private MessageBox _messageBox;


        [ObservableProperty]
        UserLoginDTO userLoginDTO = new UserLoginDTO();
        [ObservableProperty]
        BooksViewModel booksViewModel;
        [ObservableProperty]
        bool isLoading = false;

        public LoginViewModel(IAuthService authService, IConnectivity connectivity)
        {
            _authService = authService;
            _connectivity = connectivity;
            _messageBox = new MessageBox();
            userLoginDTO.Email = "";
            userLoginDTO.Password = "";
        }


        [ObservableProperty]
        string message = string.Empty;

        [RelayCommand]
        public async Task Login()
        {
            IsLoading = true;

            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                _messageBox.ShowMessage("Internet not available!");
                IsLoading = false;
                return;
            }

            var result = await _authService.Login(userLoginDTO);

            if (result.Success)
            {
                booksViewModel.IsUserAuthenticated = true;
                booksViewModel.IsUserNotAuthenticated = false;
                await SecureStorage.SetAsync("AuthToken", result.Data);
                await SecureStorage.SetAsync("email", userLoginDTO.Email);
                await Shell.Current.GoToAsync("../", true);
                booksViewModel.Email = userLoginDTO.Email;
            }
            else
            {
                Message = "Wrong email or password";
            }
            IsLoading = false;
        }

        [RelayCommand]
        public async Task Return()
        {
            await Shell.Current.GoToAsync("../", true);
        }
    }
}
