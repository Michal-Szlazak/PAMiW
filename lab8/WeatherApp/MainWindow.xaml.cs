using System.Windows;
using WeatherApp.ViewModels;

namespace WeatherApp
{
    public partial class MainWindow : Window
    {

        private readonly MainViewModel _viewModel;
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }

    }
}
