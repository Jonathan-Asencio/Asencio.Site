using System.Collections.Generic;
using Asencio.WebSite.Models;
using Asencio.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace Asencio.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        public ProjectsController(JsonFileService projectService)
        {
            ProjectService = projectService;
        }

        public JsonFileService ProjectService { get; }

        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return ProjectService.GetProjects();
        }

        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            ProjectService.AddRating(request.ProjectId, request.Rating);
            
            return Ok();
        }

        public class RatingRequest
        {
            public string ProjectId { get; set; }
            public int Rating { get; set; }
        }
    }
}