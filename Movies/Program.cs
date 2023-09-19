using Microsoft.EntityFrameworkCore;
using Movies.Config;
using Movies.Data;
using Movies.Repository;
using Movies.Repository.Implementations;
using Movies.Repository.Implementions;
using Movies.Services;
using Movies.Services.Implementations;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ExceptionFilters());
    options.Filters.Add(new Duplicate404NotFoundException());
})
    .AddNewtonsoftJson(option =>
{
    option.SerializerSettings.Converters.Add(new StringEnumConverter());
    option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
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
builder.Services.AddTransient<IGenreRepository, GenreRepository>();
builder.Services.AddTransient<IGenreService, GenreService>();
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
