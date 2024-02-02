using MyMauiApp.ViewModels;

namespace MyMauiApp;

public partial class SaveBookView : ContentPage
{
	public SaveBookView(SaveBookViewModel saveBookViewModel)
	{
		BindingContext = saveBookViewModel;
		InitializeComponent();
	}
}