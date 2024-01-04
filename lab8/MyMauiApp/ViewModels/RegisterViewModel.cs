using CommunityToolkit.Mvvm.ComponentModel;
using ProjectShared.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectShared.Services.AuthService;
using CommunityToolkit.Mvvm.Input;

namespace MyMauiApp.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly IAuthService _authService;


        [ObservableProperty]
        UserRegisterDTO userRegisterDTO = new UserRegisterDTO();

        public RegisterViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        [ObservableProperty]
        string message = string.Empty;

        [RelayCommand]
        public async Task Register()
        {
            var result = await _authService.Register(userRegisterDTO);

            if (result.Success)
            {
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
