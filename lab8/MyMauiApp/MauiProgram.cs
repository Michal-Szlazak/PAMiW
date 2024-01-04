
using Microsoft.Extensions.Logging;
using MyMauiApp.ViewModels;
using ProjectShared.Configuration;
using ProjectShared.Services.BookService;
using ProjectShared.Services.AuthService;

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
            services.AddSingleton<IBookService, BookService>();
            services.AddSingleton<IAuthService, AuthService>();
        }

        private static void ConfigureViewModels(IServiceCollection services)
        {
            services.AddSingleton<BooksViewModel>();
            services.AddTransient<SaveBookViewModel>();
            services.AddTransient<ShowDetailsViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<RegisterViewModel>();
            services.AddTransient<ErrorViewModel>();
        }

        private static void ConfigureViews(IServiceCollection services)
        {
            services.AddSingleton<MainPage>();
            services.AddTransient<SaveBookView>();
            services.AddTransient<ShowDetailsView>();
            services.AddTransient<LoginView>();
            services.AddTransient<RegisterView>();
            services.AddTransient<ErrorView>();
        }

        private static void ConfigureHttpClients(IServiceCollection services, AppSettings appSettingsSection)
        {
            var uriBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
            {
                //Path = appSettingsSection.BaseBookEndpoint.Base_url,
            };
            services.AddHttpClient<IBookService, BookService>(client => client.BaseAddress = uriBuilder.Uri);
            services.AddHttpClient<IAuthService, AuthService>(client => client.BaseAddress = uriBuilder.Uri);
        }
    }
}