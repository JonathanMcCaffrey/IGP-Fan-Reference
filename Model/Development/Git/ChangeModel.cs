using System;
using System.Collections.Generic;

namespace Model.Work.Git;

public class ChangeModel {
    public static int id;

    public static List<ChangeModel> exampleData = new() { new ChangeModel() };

    public ChangeModel() {
        Id = id++;
    }

    public int Id { get; set; } = 1;
    public int PatchModelId { get; set; } = 1;
    public string Name { get; set; } = "Add name...";
    public string Description { get; set; } = "Add desciption...";
    public string Commit { get; set; } = CommitType.Feature;
    public DateTime Date { get; set; } = DateTime.Now;
    public string Important { get; set; } = "False";
}