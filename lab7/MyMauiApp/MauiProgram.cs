
using Microsoft.Extensions.Logging;
using MyMauiApp.ViewModels;
using ProjectShared.Configuration;
using ProjectShared.Services.BookService;

namespace MyMauiApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            ConfigureServices(builder.Services);
            return builder.Build();
        }
        
        private static void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = ConfigureAppSettings(services);
            ConfigureAppServices(services, appSettingsSection);
            ConfigureViewModels(services);
            ConfigureViews(services);
            ConfigureHttpClients(services, appSettingsSection);
        }

        private static AppSettings ConfigureAppSettings(IServiceCollection services)
        {
            // pobranie appsettings z konfiguracji i zmapowanie na klase AppSettings 
            //Microsoft.Extensions.Options.ConfigurationExtensions
            //var appSettings = _configuration.GetSection(nameof(AppSettings));
            //var appSettingsSection = appSettings.Get<AppSettings>();
            // services.Configure<AppSettings>(appSettings);
            var appSettingsSection = new AppSettings()
            {
                BaseAPIUrl = "http://localhost:5093",
                BaseBookEndpoint = new BaseBookEndpoint()
                {
                    Base_url = "api/Book/",
                    GetAllBooksEndpoint = "",
                },
            };
            services.AddSingleton(appSettingsSection);
            return appSettingsSection;
        }

        private static void ConfigureAppServices(IServiceCollection services, AppSettings appSettings)
        {
            services.AddSingleton<IConnectivity>(Connectivity.Current);
            services.AddSingleton<IGeolocation>(Geolocation.Default);
            services.AddSingleton<IMap>(Map.Default);

            // konfiguracja serwisów 
            services.AddSingleton<IBookService, BookService>();
            // services.AddSingleton<IMessageDialogService, MauiMessageDialogService>();

        }

        private static void ConfigureViewModels(IServiceCollection services)
        {

            // konfiguracja viewModeli 


            services.AddSingleton<BooksViewModel>();
            // services.AddTransient<ProductDetailsViewModel>();
        }

        private static void ConfigureViews(IServiceCollection services)
        {
            // konfiguracja okienek 
            services.AddSingleton<MainPage>();
            //services.AddTransient<ProductDetailsView>();
        }

        private static void ConfigureHttpClients(IServiceCollection services, AppSettings appSettingsSection)
        {
            var uriBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
            {
                Path = appSettingsSection.BaseBookEndpoint.Base_url,
            };
            //Microsoft.Extensions.Http
            services.AddHttpClient<IBookService, BookService>(client => client.BaseAddress = uriBuilder.Uri);
        }
    }
}