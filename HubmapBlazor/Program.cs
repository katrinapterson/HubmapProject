using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using HubmapBlazor.Data;
using MudBlazor;
using MudBlazor.Services;

var bupService = new BupService(@"Resources/bup_data.tsv");
var literatureProteinService = new LiteratureProteinService(@"Resources/literature_data.tsv");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//builder.Services.AddSingleton(_ => new BupInformationProvider("file path"));
//builder.Services.AddSingleton(_ => new AntibodyCountProvider("file path"));
//builder.Services.AddSingleton(_ => new AntibodyTableProvider("file path"));
//builder.Services.AddSingleton(_ => new LiteratureInfoProvider(@"Resources/NewestLiteratureData"));
builder.Services.AddSingleton(_ => bupService);
builder.Services.AddSingleton(_ => literatureProteinService);
builder.Services.AddSingleton(_ => new AntibodyService(@"Resources/antibody_table_unconjugated_with_counts.tsv"));
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

