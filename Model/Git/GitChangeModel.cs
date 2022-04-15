namespace Model.Git;

public class GitChangeModel
{
    public int Id { get; set; } = 1;
    public int GitPatchModelId { get; set; } = 1;
    public string Name { get; set; } = "Add name...";
    public string Description { get; set; } = "Add desciption...";
    public string Commit { get; set; } = CommitType.Feature;
    public string Important { get; set; } = "False";
}