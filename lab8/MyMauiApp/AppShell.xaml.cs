namespace MyMauiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(SaveBookView), typeof(SaveBookView));
            Routing.RegisterRoute(nameof(ShowDetailsView), typeof(ShowDetailsView));
            Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
            Routing.RegisterRoute(nameof(RegisterView), typeof(RegisterView));
            Routing.RegisterRoute(nameof(ErrorView), typeof(ErrorView));
        }
    }
}