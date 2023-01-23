global using LoLInfoSQL.Client.Services.ChampionService;
global using LoLInfoSQL.Client.Services.BohaterowieService;
global using LoLInfoSQL.Client.Services.PrzedmiotyService;
global using LoLInfoSQL.Client.Services.DruzynyService;
global using LoLInfoSQL.Client.Services.GraczeZawodowiService;
global using LoLInfoSQL.Client.Services.GraczeService;
global using LoLInfoSQL.Client.Services.GryService;
global using LoLInfoSQL.Shared;
global using LoLInfoSQL.Shared.Models;
using LoLInfoSQL.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using LoLInfoSQL.Client.Authentication;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<IChampionService, ChampionService>();
builder.Services.AddScoped<IBohaterowieService, BohaterowieService>();
builder.Services.AddScoped<IPrzedmiotyService, PrzedmiotyService>();
builder.Services.AddScoped<IDruzynyService, DruzynyService>();
builder.Services.AddScoped<IGraczeZawodowiService, GraczeZawodowiService>();
builder.Services.AddScoped<IGraczeService, GraczeService>();
builder.Services.AddScoped<IGryService, GryService>();

await builder.Build().RunAsync();
