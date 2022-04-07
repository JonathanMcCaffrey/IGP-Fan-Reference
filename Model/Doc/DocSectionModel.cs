using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Doc;

public class DocSectionModel
{
    [Key] public int Id { get; set; }

    public string Name { get; set; }

    [NotMapped]
    public virtual ICollection<DocContentModel> DocumentationModels { get; set; } = new List<DocContentModel>();
}