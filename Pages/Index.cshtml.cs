using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asencio.WebSite.Models;
using Asencio.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Asencio.WebSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger,
            JsonFileService projectService)
        {
            _logger = logger;
            ProjectService = projectService;
        }

        public JsonFileService ProjectService { get; }
        public IEnumerable<Project> Projects { get; private set; }

        public void OnGet()
        {
            Projects = ProjectService.GetProjects();
        }
    }
}
