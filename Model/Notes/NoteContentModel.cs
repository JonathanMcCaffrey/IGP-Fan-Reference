using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Model.Website;

namespace Model.Notes;

public class NoteContentModel
{
    public int Id { get; set; }

    public int? ParentId { get; set; } = null;

    public int? NoteSectionModelId { get; set; } = null;

    public string Href { get; set; }
    //public DateTime LastUpdated { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
    public string Content { get; set; }
    
    
    [NotMapped]
    public virtual string LoadedContent { get; set; }

    
    public string IsHidden { get; set; } = "False";
    public string IsPreAlpha { get; set; } = "True";

    public List<SearchPointModel> GetHeaders()
    {
        var regex = new Regex(@"^#* (.*)$", RegexOptions.Multiline);
        var listOfMatches = regex.Matches(LoadedContent);
        
        Console.WriteLine($"Name: {Name}");
        
        Console.WriteLine($"Matches: {listOfMatches.Count}");

        List<SearchPointModel> foundHeaders = new List<SearchPointModel>();
        
        foreach (var capture in listOfMatches)
        {
            var cleanUp = capture.ToString();
            cleanUp = cleanUp.ToLower();
            cleanUp = cleanUp.Replace("#", "");
            cleanUp = cleanUp.Replace("#", "");
            cleanUp = cleanUp.Replace("\"", "");
            cleanUp = cleanUp.Trim();
            cleanUp = cleanUp.Replace(" ", "-");
           foundHeaders.Add(new SearchPointModel(){ Title = capture.ToString().Trim(), Href = cleanUp});
            Console.WriteLine($"Capture: {cleanUp}");
        }

        return foundHeaders;
    }
    
    [NotMapped]
    public virtual ICollection<NoteContentModel> NoteContentModels { get; set; } = new List<NoteContentModel>();

    [NotMapped] public virtual NoteContentModel Parent { get; set; }
    [NotMapped] public virtual int PageOrder { get; set; }


    private string GetLink()
    {
        var link = Href;

        if (Parent != null) link = $"{Parent.GetLink()}/" + link;

        return link;
    }

    public string GetNoteLink()
    {
        return $"notes/{GetLink()}";
    }
}