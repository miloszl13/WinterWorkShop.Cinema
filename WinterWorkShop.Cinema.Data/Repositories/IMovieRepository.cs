using WinterWorkShop.Cinema.Data.Models;

namespace WinterWorkShop.Cinema.Data.Repositories
{
    public interface IMovieRepository
    {
        List<MovieModel> GetAllMovies();

        MovieModel? GetMovieById(int id);

        
    }
}