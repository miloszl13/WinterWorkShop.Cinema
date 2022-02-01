using Microsoft.AspNetCore.Mvc;
using WinterWorkShop.Cinema.Domain.Responses;
using WinterWorkShop.Cinema.Domain.Common;
using WinterWorkShop.Cinema.API.Models;
using WinterWorkShop.Cinema.Data.Repositories;

namespace WinterWorkShop.Cinema.API.Controllers
{
    [ApiController]
    [Route("movies")]
    public class MoviesController : BaseController
    {
        public readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet()]
        public List<MovieResponse> GetMovies()
        {
            var movies = _movieRepository.GetAllMovies();

            var result = new List<MovieResponse>();

            foreach (var movie in movies)
            {
                result.Add(new MovieResponse
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Genre = movie.Genre,
                    Duration = movie.Duration,
                    Rating = movie.Rating
                });
            }

            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<MovieResponse> GetMovieById(int id)
        {
            var movie = _movieRepository.GetMovieById(id);

            if (movie == null)
            {
                ErrorResponseModel errorResponse = new ErrorResponseModel()
                {
                    ErrorMessage = Messages.MOVIE_DOES_NOT_EXIST,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
                return NotFound(errorResponse);
            }

            var result = new MovieResponse()
            {
                Id = id,
                Name = movie.Name,
                Genre = movie.Genre,
                Duration = movie.Duration,
                Rating = movie.Rating
            };

            return result;
        }
    }
}