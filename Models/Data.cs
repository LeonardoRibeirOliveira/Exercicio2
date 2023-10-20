using Microsoft.Extensions.Hosting;

namespace Exercicio2.Models
{
    public class Data
    {
        public string? title { get; set; }
        public string url { get; set; }
        public string author { get; set; }
        public string? num_comments { get; set; }
        public int? story_id { get; set; }
        public string? story_title { get; set; }
        public string? story_url { get; set; }
        public DateTime created_at { get; set; }
        public int pageArtigo { get; set; }
    }
}
