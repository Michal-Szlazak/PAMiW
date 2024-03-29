using BlazorApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProjectShared.Services.BookService;
using ProjectShared.Configuration;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorApp.Services;
using Blazored.LocalStorage;
using ProjectShared.Services.AuthService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var appSettings = builder.Configuration.GetSection(nameof(AppSettings));
var appSettingsSection = appSettings.Get<AppSettings>();

var uriBuilder = new UriBuilder(appSettingsSection.BaseAPIUrl)
{
    //Path = appSettingsSection.BaseBookEndpoint.Base_url
};
builder.Services.AddHttpClient<IBookService, BookService>(client => client.BaseAddress = uriBuilder.Uri);

builder.Services.AddSingleton(appSettingsSection);
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddHttpClient<IAuthService, AuthService>(client => client.BaseAddress = uriBuilder.Uri);

await builder.Build().RunAsync();
