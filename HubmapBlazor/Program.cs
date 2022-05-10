using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using HubmapBlazor.Data;
using HubmapProject;
using MudBlazor;
using MudBlazor.Services;


var bupService = new BupService(@"../HubmapProject/Resources/NewBupData");
var literatureProteinService = new LiteratureProteinService(@"../HubmapProject/Resources/NewestLiteratureData");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton(_ => new BupInformationProvider("file path"));
builder.Services.AddSingleton(_ => new AntibodyCountProvider("file path"));
builder.Services.AddSingleton(_ => new AntibodyTableProvider("file path"));
builder.Services.AddSingleton(_ => new LiteratureInfoProvider(@"../HubmapProject/Resources/NewestLiteratureData"));
builder.Services.AddSingleton(_ => bupService);
builder.Services.AddSingleton(_ => literatureProteinService);
builder.Services.AddSingleton(_ => new AntibodyService(@"../HubmapProject/Resources/antibody_table_unconjugated.tsv"));
builder.Services.AddSingleton(_ => new TissueProvider(bupService, literatureProteinService));


builder.Services.AddSingleton(_ => new WeatherForecastService());

builder.Services.AddMudServices();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

