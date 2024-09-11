using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DocExtractor
{
    public class NavigationPage
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }
    }

    public class Navigation
    {
        [JsonPropertyName("group")]
        public string Group { get; set; }

        [JsonPropertyName("pages")]
        public IEnumerable<NavigationPage> Pages { get; set; }
    }

    public class NavigationRoot
    {
        [JsonPropertyName("navigation")]
        public IEnumerable<Navigation> Navigation { get; set; }
    }

    public class JSONIndex
    {
        public static void Generate(Configuration configuration, List<MarkdownOutput> outputs)
        {
            var pages = outputs.Select(o => new NavigationPage { Path = o.Path, Title = o.Title });

            var navigationRoot = new NavigationRoot
            {
                Navigation = new List<Navigation>
                {
                    new Navigation {
                        Group = "API Documentation",
                        Pages = pages
                    }
                },
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(navigationRoot, options);
            var path = Path.Join(configuration.OutputFolder, "index.json");
            File.WriteAllText(path, json);
        }
    }
}