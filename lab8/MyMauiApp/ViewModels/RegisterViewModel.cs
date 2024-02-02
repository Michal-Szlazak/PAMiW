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
        private readonly IConnectivity _connectivity;
        private MessageBox _messageBox;


        [ObservableProperty]
        UserRegisterDTO userRegisterDTO = new UserRegisterDTO();
        [ObservableProperty]
        bool isLoading = false;

        public RegisterViewModel(IAuthService authService, IConnectivity connectivity)
        {
            _authService = authService;
            _connectivity = connectivity;
            _messageBox = new MessageBox();
        }

        [ObservableProperty]
        string message = string.Empty;

        [RelayCommand]
        public async Task Register()
        {
            IsLoading = true;

            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                _messageBox.ShowMessage("Internet not available!");
                IsLoading = false;
                return;
            }

            var result = await _authService.Register(userRegisterDTO);

            if (result.Success)
            {
                await Shell.Current.GoToAsync("../", true);
            }
            else
            {
                Message = "Wrong data";
            }
            IsLoading = true;
        }

        [RelayCommand]
        public async Task Return()
        {
            await Shell.Current.GoToAsync("../", true);
        }
    }
}
