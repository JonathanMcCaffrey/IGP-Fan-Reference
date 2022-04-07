using System;

namespace Model.Development.Git;

public class GitChangeModel
{
    public int Id { get; set; } = 1;
    public int GitPatchModelId { get; set; } = 1;
    public string Name { get; set; } = "Add name...";
    public string Description { get; set; } = "Add desciption...";
    public string Commit { get; set; } = CommitType.Feature;
    public DateTime Date { get; set; } = DateTime.Now;
    public string Important { get; set; } = "False";
}