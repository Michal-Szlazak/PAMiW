using System;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WeatherApp.ViewModels;
using WeatherApp.service.WeatherServices;
using Microsoft.Extensions.Configuration;
using System.IO;
using WeatherApp.Configuration;
using ProjectShared.Services.BookService;

namespace WeatherApp
{

    public partial class App : Application
    {
        IServiceProvider _serviceProvider;
        IConfiguration _configuration;

        public App()
        {
            var builder = new ConfigurationBuilder()
              .AddUserSecrets<App>()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json");
            _configuration = builder.Build();



            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();

        }

        private void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = ConfigureAppSettings(services);
            ConfigureAppServices(services);
            ConfigureViewModels(services);
            ConfigureViews(services);
            ConfigureHttpClients(services, appSettingsSection);
        }

        private AppSettings ConfigureAppSettings(IServiceCollection services)
        {
            var appSettings = _configuration.GetSection(nameof(AppSettings));
            var appSettingsSection = appSettings.Get<AppSettings>();
            services.Configure<AppSettings>(appSettings);
            return appSettingsSection;
        }

        private void ConfigureAppServices(IServiceCollection services)
        {
            services.AddSingleton<IWeatherService, WeatherService>();
            services.AddSingleton<IBookService, BookService>();
            services.AddSingleton<ILocationsService, LocationService>();
        }

        private void ConfigureViewModels(IServiceCollection services)
        {
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<BooksViewModel>();
        }

        private void ConfigureViews(IServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            services.AddTransient<BookStoreView>();
            services.AddTransient<BookDetailsView>();
        }

        private void ConfigureHttpClients(IServiceCollection services, AppSettings appSettingsSection)
        {
            var uriBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
            {
                Path = appSettingsSection.BaseBookEndpoint.Base_url,
            };
            services.AddHttpClient<IBookService, BookService>(client => client.BaseAddress = uriBuilder.Uri);
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

    }
}

