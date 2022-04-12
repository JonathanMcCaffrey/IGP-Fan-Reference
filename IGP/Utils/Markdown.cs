using Markdig;
using Markdig.Extensions.Yaml;
using Markdig.Syntax;
using Model.Doc;
using YamlDotNet.Serialization;

namespace IGP.Utils;

public static class MarkdownFiles {
    private static readonly IDeserializer YamlDeserializer = 
        new DeserializerBuilder()
            .IgnoreUnmatchedProperties()
            .Build();
    
    public static readonly MarkdownPipeline Pipeline 
        = new MarkdownPipelineBuilder()
            .UseYamlFrontMatter()
            .UseAdvancedExtensions()
            .Build();

    public static async Task<string> LoadMarkdown(HttpClient httpClient, string filepath)
    {
        return await httpClient.GetStringAsync(filepath);
    }
    
    public static async Task<T> LoadFrontMatter<T>(HttpClient httpClient, string filepath) {
        var markdown = await LoadMarkdown(httpClient, filepath);

        var document = Markdown.Parse(markdown, Pipeline);
        
        var block = document
            .Descendants<YamlFrontMatterBlock>()
            .FirstOrDefault();

        if (block == null) 
            return default!;
        
        var yaml =
            block
                .Lines 
                .Lines 
                .OrderByDescending(x => x.Line)
                .Select(x => $"{x}\n")
                .ToList()
                .Select(x => x.Replace("---", string.Empty))
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Aggregate((s, agg) => agg + s);
        
        return YamlDeserializer.Deserialize<T>(yaml);
    }
}