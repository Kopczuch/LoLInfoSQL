global using LoLInfoSQL.Client.Services.ChampionService;
global using LoLInfoSQL.Client.Services.BohaterowieService;
global using LoLInfoSQL.Client.Services.PrzedmiotyService;
global using LoLInfoSQL.Shared;
global using LoLInfoSQL.Shared.Models;
using LoLInfoSQL.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IChampionService, ChampionService>();
builder.Services.AddScoped<IBohaterowieService, BohaterowieService>();
builder.Services.AddScoped<IPrzedmiotyService, PrzedmiotyService>();

await builder.Build().RunAsync();
