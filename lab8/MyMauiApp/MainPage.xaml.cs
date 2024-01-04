using MyMauiApp.ViewModels;

namespace MyMauiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(BooksViewModel booksViewModel)
        {
            InitializeComponent();
            BindingContext = booksViewModel;
        }
    }
}