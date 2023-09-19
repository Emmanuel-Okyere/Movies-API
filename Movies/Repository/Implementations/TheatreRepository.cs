using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Model;

namespace Movies.Repository.Implementations;

public class TheatreRepository : ITheatreRepository
{
    private readonly DataContext _dataContext;

    public TheatreRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public Theatre? GetTheatreById(int id)
    {
        return _dataContext.Theatres.Include(t=>t.Movies).FirstOrDefault(t=>t.Id==id);
    }

    public Theatre AddTheatre(Theatre theatre)
    {
        var savedTheatre =_dataContext.Theatres.Add(theatre);
        _dataContext.SaveChangesAsync();
        return savedTheatre.Entity;
    }

    public async Task<IEnumerable<Theatre>> GetAllTheatres()
    {
        return await _dataContext.Theatres.ToListAsync();
    }

    // public IEnumerable<Movie> GetAllMoviesInATheatre(Theatre theatre)
    // {
    //     return theatre.Movies;
    // }

    public async void DeleteTheatre(Theatre theatre)
    {
        _dataContext.Theatres.Remove(theatre);
        await _dataContext.SaveChangesAsync();
    }

    public Theatre UpdateTheatre(Theatre theatre)
    {
        var updatedTheatre = _dataContext.Theatres.Update(theatre);
        _dataContext.SaveChanges();
        return updatedTheatre.Entity;
    }

    public int AddMovieToTheatre(Theatre theatre,Movie movie)
    {
        theatre.Movies.Add(movie);
        var status =_dataContext.SaveChanges();
        return status;
    }

    public Theatre? GetTheatreByNameAndLocation(string name, string location)
    {
        var theatre = _dataContext.Theatres.SingleOrDefault(a => a.Name == name && a.Location == location);
        return theatre;
    }

    public void SaveChanges()
    {
        _dataContext.SaveChanges();
    }
    
}