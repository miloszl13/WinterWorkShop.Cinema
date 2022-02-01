using Microsoft.AspNetCore.Mvc;
using WinterWorkShop.Cinema.Data.Repositories;
using WinterWorkShop.Cinema.Domain.Responses;

namespace WinterWorkShop.Cinema.API.Controllers
{
    [ApiController]
    [Route("projections")]
    public class ProjectionsController : BaseController
    {
        public readonly IProjectionRepository projection;

        public ProjectionsController(IProjectionRepository projection)
        {
            this.projection = projection;
        }
        [HttpGet()]

        public List<ProjectionResponse> GetMovies()
        {
            var projections = projection.GetAllProjections();

            var result = new List<ProjectionResponse>();

            foreach (var projection in projections)
            {
                result.Add(new ProjectionResponse
                {
                    ProjectionId = projection.ProjectionId,
                    Date = projection.Date,
                    AuditoriumName = projection.AuditoriumName
                });
            }

            return result;
        }

    }
}