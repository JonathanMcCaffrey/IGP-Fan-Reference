using System;
using System.Collections.Generic;

namespace Model.Git;

public class GitPatchModel
{
    public int Id { get; set; } = 1;
    public string Name { get; set; } = "Add name...";
    public DateTime Date { get; set; } = DateTime.Now;
    public ICollection<GitChangeModel> GitChangeModels { get; set; } = new List<GitChangeModel>();
    public string Important { get; set; } = "False";
}