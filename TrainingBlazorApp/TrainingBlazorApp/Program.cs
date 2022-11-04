using Blazored.Toast;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TrainingBlazorApp.Data;
using TrainingBlazorApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<MahasiswaDb>();
builder.Services.AddTransient<MahasiswaService>();
builder.Services.AddBlazoredToast();
builder.Services.AddQuickGridEntityFrameworkAdapter();

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

MahasiswaDb db = new();
db.Database.EnsureCreated();
/*
Random rnd = new Random();
for(var i = 0; i < 5; i++)
{
    var item = new Mahasiswa() { IPK = rnd.Next(2,4), Kelamin = JenisKelamin.Laki, Nama = $"Asep {i}", NIM = rnd.Next(1000,9999).ToString(), TanggalLahir = DateTime.Now.AddYears(-rnd.Next(10,20)) };
    db.Mahasiswas.Add(item);
}

db.SaveChanges();
 */
app.Run();
