using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMauiApp.ViewModels
{
    public partial class ErrorViewModel : ObservableObject
    {
        [RelayCommand]
        public async Task Return()
        {
            await Shell.Current.GoToAsync("../", true);
        }
    }
}
