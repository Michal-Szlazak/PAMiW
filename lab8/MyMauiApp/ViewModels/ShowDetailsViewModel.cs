using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectShared.BookStore;

namespace MyMauiApp.ViewModels
{

    [QueryProperty(nameof(Book), nameof(Book))]
    [QueryProperty(nameof(BooksViewModel), nameof(BooksViewModel))]
    public partial class ShowDetailsViewModel : ObservableObject
    {
        public ShowDetailsViewModel() { }

        [ObservableProperty]
        private BooksViewModel _booksViewModel;

        [ObservableProperty]
        Book book;

        [RelayCommand]
        public async Task GoBack()
        {
            await Shell.Current.GoToAsync("../", true);
        }
    }
}
