using WinterWorkShop.Cinema.Data.Models;

namespace WinterWorkShop.Cinema.Data.Repositories
{
    public interface IProjectionRepository
    {
        List<ProjectionModel> GetAllProjections();
        ProjectionModel? GetProjectionByID(int id);
    }
}
