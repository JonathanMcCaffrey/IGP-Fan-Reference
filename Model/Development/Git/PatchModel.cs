using System;
using System.Collections.Generic;

namespace Model.Work.Git;

public class PatchModel {
    public static int id;

    public static List<PatchModel> exampleData = new() { new PatchModel { ChangeModels = ChangeModel.exampleData } };

    public PatchModel() {
        Id = id++;
    }

    public int Id { get; set; } = 1;
    public string Name { get; set; } = "Add name...";
    public DateTime Date { get; set; } = DateTime.Now;
    public virtual ICollection<ChangeModel> ChangeModels { get; set; } = new List<ChangeModel>();

    public string Important { get; set; } = "False";

    public PatchModel AddChange(ChangeModel changeModel) {
        if (ChangeModels == null) ChangeModels = new List<ChangeModel>();

        changeModel.PatchModelId = Id;
        ChangeModels.Add(changeModel);
        return this;
    }

    public PatchModel ConnectChildren() {
        foreach (var change in ChangeModels) change.PatchModelId = Id;
        return this;
    }
}