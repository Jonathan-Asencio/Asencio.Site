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
    }
}