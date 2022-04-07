using System.ComponentModel.DataAnnotations;

namespace Model.Notes;

public class NoteConnectionModel
{
    [Key] public int Id { get; set; } = 1;
    public int ParentId { get; set; } = 1;
    public int ChildId { get; set; } = 1;
}