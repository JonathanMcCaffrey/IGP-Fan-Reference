using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Notes;

public class NoteSectionModel
{
    [Key] public int Id { get; set; }

    public string Name { get; set; }

    [NotMapped]
    public virtual ICollection<NoteContentModel> NoteContentModels { get; set; } = new List<NoteContentModel>();
}