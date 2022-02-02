using WinterWorkShop.Cinema.Data.Models;

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
            List<ProjectionModel> projectionsbymovieid = new List<ProjectionModel>();
            foreach (ProjectionModel p in database.Projections)
            {
                if (p.MovieID == id)
                {

                    projectionsbymovieid.Add(p);
                }
            }

            return projectionsbymovieid;
        }
    }
}
