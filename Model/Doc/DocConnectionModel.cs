using System.ComponentModel.DataAnnotations;

namespace Model.Doc;

public class DocConnectionModel
{
    [Key] public int Id { get; set; } = 1;
    public int ParentId { get; set; } = 1;
    public int ChildId { get; set; } = 1;
}