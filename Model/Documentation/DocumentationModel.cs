using System;

namespace Model.Documentation;

public class DocumentationModel
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string Name { get; set; }
    public string Section { get; set; }
    public string Description { get; set; }
}