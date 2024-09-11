using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Navigation
{
    [JsonPropertyName("group")]
    public string Group { get; set; }

    [JsonPropertyName("pages")]
    public List<string> Pages { get; set; }
}

public class NavigationRoot
{
    [JsonPropertyName("navigation")]
    public List<Navigation> Navigation { get; set; }
}

public class JSONIndex
{
    public static void Generate(Configuration configuration)
    {
        var navigationRoot = new NavigationRoot
        {
            Navigation = new List<Navigation>
            {
                new Navigation
                {
                    Group = "Get Started",
                    Pages = new List<string> { "introduction", "quickstart", "development" }
                },
                new Navigation
                {
                    Group = "Essentials",
                    Pages = new List<string> 
                    { 
                        "essentials/markdown",
                        "essentials/code",
                        "essentials/images",
                        "essentials/settings",
                        "essentials/navigation",
                        "essentials/reusable-snippets",
                        "svelte-marked"
                    }
                },
                new Navigation
                {
                    Group = "API Documentation",
                    Pages = new List<string> { "api-reference/introduction" }
                },
                new Navigation
                {
                    Group = "Endpoint Examples",
                    Pages = new List<string> 
                    {
                        "api-reference/endpoint/get",
                        "api-reference/endpoint/create",
                        "api-reference/endpoint/delete"
                    }
                }
            }
        };

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(navigationRoot, options);
        Console.WriteLine(json);
    }
}
