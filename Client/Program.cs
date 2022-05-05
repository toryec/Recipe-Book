using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp.Client;
using BlazorApp.Client.Helpers;
using FluentValidation;
using BlazorApp.Shared.Dtos;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services
    .AddHttpClient<IRecipeHttpService, RecipeHttpService>()
    .ConfigureHttpClient(opt => opt.BaseAddress = new Uri(Path.Combine(builder.HostEnvironment.BaseAddress, "api/")));
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// builder.Services.AddTransient<IValidator<ReadRecipeDto>, RecipeModelValidator>();
await builder.Build().RunAsync();
