﻿using Microsoft.AspNetCore.Mvc;
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
        public readonly IProjectionRepository projectionn;

        public ProjectionsController(IProjectionRepository projection)
        {
            projectionn = projection;
        }
        [HttpGet()]

        public List<ProjectionResponse> GetMovies()
        {
            var projections = projectionn.GetAllProjections();

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
            var projection = projectionn.GetProjectionByID(id);

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

    }
}