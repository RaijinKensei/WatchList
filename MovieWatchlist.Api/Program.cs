using Microsoft.EntityFrameworkCore;
using MovieWatchlist.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpClient("MovieAPI", client =>
{
    client.BaseAddress = new Uri("https://moviewatchlistapi20250714201901-bkcpgeccgggcfzcv.canadacentral-01.azurewebsites.net"); 
});

//Db Context in SqlServer
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Redirect dalla root "/" a "/api/search"
app.MapGet("/", context =>
{
    context.Response.Redirect("/api/search/?title=The+Matrix");
    return Task.CompletedTask;
});

app.Run();
