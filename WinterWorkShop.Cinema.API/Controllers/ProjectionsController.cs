using Microsoft.AspNetCore.Mvc;
using WinterWorkShop.Cinema.Data.Repositories;
using WinterWorkShop.Cinema.Domain.Responses;
using WinterWorkShop.Cinema.API.Models;
using WinterWorkShop.Cinema.Domain.Common;

namespace WinterWorkShop.Cinema.API.Controllers
{
    [ApiController]
    [Route("projections")]
    public class ProjectionsController : BaseController
    {
        public readonly IProjectionRepository _projectionRepository;

        public ProjectionsController(IProjectionRepository projection)
        {
            _projectionRepository = projection;
        }
        [HttpGet()]

        public List<ProjectionResponse> GetMovies()
        {
            var projections = _projectionRepository.GetAllProjections();

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
        [HttpGet("{id}")]
        public ActionResult<ProjectionResponse> GetProjectionByID(int id)
        {
            var projection = _projectionRepository.GetProjectionByID(id);

            if (projection == null)
            {
                ErrorResponseModel errorResponse = new ErrorResponseModel()
                {
                    ErrorMessage = Messages.PROJECTION_DOES_NOT_EXIST,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
                return NotFound(errorResponse);
            }

            var result = new ProjectionResponse()
            {
                ProjectionId = id,
                Date = projection.Date,
                AuditoriumName = projection.AuditoriumName
    
            };

            return result;
        }
        [HttpGet("movie/{id}")]
        public ActionResult<List<ProjectionResponse>> GetProjectionByMovieId(int id)
        {
            var projections = _projectionRepository.GetProjectionsByMovieId(id);


            if (projections == null)
            {
                ErrorResponseModel errorResponse = new ErrorResponseModel()
                {
                    ErrorMessage = Messages.MOVIE_DOES_NOT_HAVE_PROJECTIONS,
                    StatusCode = System.Net.HttpStatusCode.NotFound
                };
                return NotFound(errorResponse);
            }
            var result = new List<ProjectionResponse>();
            
            foreach (var projection in projections)
            {
                result.Add(new ProjectionResponse
                {
                    ProjectionId = projection.ProjectionId,
                    Date = projection.Date,
                    AuditoriumName = projection.AuditoriumName,
                    MovieID=projection.MovieID
                });
            }
            return result;
        }

    }
}