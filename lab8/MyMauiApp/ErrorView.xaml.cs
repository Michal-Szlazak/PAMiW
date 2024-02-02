namespace MyMauiApp;
using MyMauiApp.ViewModels;

public partial class ErrorView : ContentPage
{
	public ErrorView(ErrorViewModel errorViewModel)
	{
        InitializeComponent();
		BindingContext = errorViewModel;
	}
}