using MyMauiApp.ViewModels;

namespace MyMauiApp;

public partial class ShowDetailsView : ContentPage
{
	public ShowDetailsView(ShowDetailsViewModel showDetailsViewModel)
	{
		BindingContext = showDetailsViewModel;
		InitializeComponent();
	}
}