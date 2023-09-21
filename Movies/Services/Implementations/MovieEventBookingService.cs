using Movies.dto;
using Movies.Exceptions;
using Movies.Model;
using Movies.Repository;
using Movies.Repository.Interfaces;
using Movies.Services.Interfaces;

namespace Movies.Services.Implementations;

public class MovieEventBookingService: IMovieEventBookingService
{
    private readonly IMovieEventBookingRepository _movieEventBookingRepository;
    private readonly IMovieShowRepository _movieShowRepository;
    private readonly ITicketRepository _ticketRepository;

    public MovieEventBookingService(IMovieEventBookingRepository movieEventBookingRepository, IMovieShowRepository movieShowRepository, ITicketRepository ticketRepository)
    {
        _movieEventBookingRepository = movieEventBookingRepository;
        _movieShowRepository = movieShowRepository;
        _ticketRepository = ticketRepository;
    }

    public async Task<MessageResponseDTO> CreateAMovieEventBooking(MovieEventBookingDto movieEventBookingDto)
    {
        var movieShow = await _movieShowRepository.GetMovieShowById(movieEventBookingDto.MovieEventId);
        if (movieShow == null)
        {
            throw new NotFound404Exception("movie event not found");
        }

        if (movieEventBookingDto.NumberOfPersons > movieShow.Tickets.NumberOfTicketsLeft)
        {
            throw new Duplicate409Exception("ticket can't satisfy you ticket left: "+movieShow.Tickets.NumberOfTicketsLeft);
        }

        var movieBookingEvent = new MovieEventBooking
        {
            AmountPayable = movieShow.Tickets.TicketPrice * movieEventBookingDto.NumberOfPersons,
            EmailAddress = movieEventBookingDto.EmailAddress,
            IsPaid = false,
            NumberOfPersons = movieEventBookingDto.NumberOfPersons,
            MovieShow = movieShow,
            TicketNumber = movieShow.Tickets.NumberOfTicketsSold+1
        };
        var savedMovieEventBooking = await _movieEventBookingRepository.CreateAMovieEventBooking(movieBookingEvent);
        movieShow.MovieEventBookings.Add(savedMovieEventBooking);
        movieShow.Tickets.NumberOfTicketsSold += movieEventBookingDto.NumberOfPersons;
        _movieEventBookingRepository.SaveChanges();
        _movieShowRepository.SaveChanges();
        return new MessageResponseDTO
        {
            message = "movie event book success",
            status = "success"
        };
    }

    public async Task<IEnumerable<MovieEventBooking>> GetAllBookings()
    {
        return await _movieEventBookingRepository.GetAllBookings();
    }

    public async Task<MovieEventBooking> GetBookingById(int id)
    {
        var movieEventBooking = await _movieEventBookingRepository.GetBookingById(id);
        if (movieEventBooking == null)
        {
            throw new NotFound404Exception("movie event booking not found");
        }

        return movieEventBooking;
    }
}