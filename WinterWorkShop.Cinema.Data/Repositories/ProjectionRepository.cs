using WinterWorkShop.Cinema.Data.Models;
using WinterWorkShop.Cinema.Domain.Responses;

namespace WinterWorkShop.Cinema.Data.Repositories
{
    public class ProjectionRepository : IProjectionRepository
    {
        public Database database = new Database();
       
        public List<ProjectionModel> GetAllProjections()
        {
            return database.Projections;
        }
        public ProjectionModel GetProjectionByID(int id)
        {
            var projection = database.Projections.FirstOrDefault(x => x.ProjectionId == id);

            return projection;
        }
        public List<ProjectionModel>? GetProjectionsByMovieId(int id)
        {
            var MovieExist = database.GetAllMoviesResponses.Any(x=>x.Id == id);

            if (MovieExist)
            {
                var projections = database.Projections.Where(p => p.MovieID == id).ToList();
                return projections;
            }
            return null;
        }
    }
}
