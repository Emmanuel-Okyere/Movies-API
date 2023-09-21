using Movies.dto;
using Movies.Model;

namespace Movies.Repository.Interfaces;

public interface IMovieEventBookingRepository
{
    Task<MovieEventBooking> CreateAMovieEventBooking(MovieEventBooking movieEventBooking);
    Task<IEnumerable<MovieEventBooking>> GetAllBookings();
    Task<MovieEventBooking?> GetBookingById(int id);
    void SaveChanges();
}