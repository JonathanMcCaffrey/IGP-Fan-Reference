using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Doc;

public class DocContentModel
{
    [Key] public int Id { get; set; } = 1;

    public int? ParentId { get; set; } = null;
    public int? DocSectionModelId { get; set; } = null;
    public string Href { get; set; }

    [NotMapped]
    public virtual ICollection<DocContentModel> DocumentationModels { get; set; } = new List<DocContentModel>();

    [NotMapped] public virtual DocContentModel Parent { get; set; }
    [NotMapped] public virtual int PageOrder { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = null;
    public string Content { get; set; } = "";

    private string GetLink()
    {
        var link = Href;

        if (Parent != null) link = $"{Parent.GetLink()}/" + link;

        return link;
    }

    public string GetDocLink()
    {
        return $"docs/{GetLink()}";
    }
}