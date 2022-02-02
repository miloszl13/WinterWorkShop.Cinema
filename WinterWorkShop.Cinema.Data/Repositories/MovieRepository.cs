using WinterWorkShop.Cinema.Data.Models;

namespace WinterWorkShop.Cinema.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        public Database Database = new Database();
        

        public List<MovieModel> GetAllMovies()
        {
            return Database.GetAllMoviesResponses;
        }

        public MovieModel GetMovieById(int id)
        {
            var movie = Database.GetAllMoviesResponses.FirstOrDefault(x => x.Id == id);

            return movie;
        }

        
    }
}
