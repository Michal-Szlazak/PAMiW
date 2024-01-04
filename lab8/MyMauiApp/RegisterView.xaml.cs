namespace MyMauiApp;
using MyMauiApp.ViewModels;

public partial class RegisterView : ContentPage
{
	public RegisterView(RegisterViewModel registerViewModel)
	{
		InitializeComponent();
        BindingContext = registerViewModel;
    }
}