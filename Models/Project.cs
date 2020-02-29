using System.Text.Json;
using System.Text.Json.Serialization;

namespace Asencio.WebSite.Models
{
    //Project model
    public class Project
    {
        public string Id { get; set; }
        
        [JsonPropertyName("img")]
        public string Image { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Project>(this);

 
    }
}