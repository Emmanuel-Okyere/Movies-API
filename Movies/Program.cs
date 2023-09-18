using Microsoft.EntityFrameworkCore;
using Movies.Config;
using Movies.Data;
using Movies.Repository;
using Movies.Repository.Implementions;
using Movies.Services;
using Movies.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ExceptionFilters());
    options.Filters.Add(new Duplicate404NotFoundException());
});
//Database Configurations
builder.Services
    .AddDbContext<DataContext>(
    option => option
        .UseNpgsql(builder
            .Configuration.GetConnectionString("connection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IMoviesRepository, MoviesRepository>();
builder.Services.AddTransient<ITheatreService, TheatreService>();
builder.Services.AddScoped<ITheatreRepository, TheatreRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
