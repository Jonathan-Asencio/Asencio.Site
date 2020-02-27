using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Asencio.WebSite.Models;
using Microsoft.AspNetCore.Hosting;

namespace Asencio.WebSite.Services
{
   public class JsonFileService
    {
        public JsonFileService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "projects.json"); }
        }

        public IEnumerable<Project> GetProjects()
        {
            using(var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Project[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        public void AddRating(string projectId, int rating)
        {
            var projects = GetProjects();

            if(projects.First(x => x.Id == projectId).Ratings == null)
            {
                projects.First(x => x.Id == projectId).Ratings = new int[] { rating };
            }
            else
            {
                var ratings = projects.First(x => x.Id == projectId).Ratings.ToList();
                ratings.Add(rating);
                projects.First(x => x.Id == projectId).Ratings = ratings.ToArray();
            }

            using(var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Project>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    projects
                );
            }
        }
    }

}