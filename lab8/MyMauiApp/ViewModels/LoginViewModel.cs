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


        [ObservableProperty]
        UserLoginDTO userLoginDTO = new UserLoginDTO();
        [ObservableProperty]
        BooksViewModel booksViewModel;

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;
            userLoginDTO.Email = "";
            userLoginDTO.Password = "";
        }


        [ObservableProperty]
        string message = string.Empty;

        [RelayCommand]
        public async Task Login()
        {
            var result = await _authService.Login(userLoginDTO);

            if (result.Success)
            {
                booksViewModel.IsUserAuthenticated = true;
                booksViewModel.IsUserNotAuthenticated = false;
                await SecureStorage.SetAsync("AuthToken", result.Data);
                await Shell.Current.GoToAsync("../", true);
            }
            else
            {
                message = result.Message;
            }
        }

        [RelayCommand]
        public async Task Return()
        {
            await Shell.Current.GoToAsync("../", true);
        }
    }
}
