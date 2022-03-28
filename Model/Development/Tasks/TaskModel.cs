using System;
using System.Collections.Generic;
using System.Linq;
using Model.Work.Tasks.Enums;

namespace Model.Work.Tasks;

public class TaskModel {
    private static int id = 1;

    public TaskModel() {
        Id = id++;
    }

    public int Id { get; set; } = 1;
    public int? SprintModelId { get; set; } = null;
    public string Name { get; set; } = "Add name...";
    public string Description { get; set; } = "Add description...";
    public string Notes { get; set; } = "Add notes...";
    public string Status { get; set; } = StatusType.Fun_Idea;
    public string Priority { get; set; } = PriorityType.Medium;
    public string Task { get; set; } = TaskType.Feature;

    public string Project { get; set; }

    public DateTime? Created { get; set; } = null;
    public DateTime? Finished { get; set; } = null;

    public string StatusColor() {
        return Status == StatusType.Fun_Idea ? "gray"
            : Status == StatusType.In_Progress ? "#3be330"
            : Status == StatusType.To_Test ? "cyan"
            : Status == StatusType.Todo ? "yellow"
            : Status == StatusType.Done ? "orange"
            : "white";
    }

    public static List<string> Statuses(List<TaskModel> Data) {
        return (from task in Data
            select task.Status).Distinct().ToList();
    }

    public static List<string> Projects(List<TaskModel> Data) {
        return (from task in Data
            select task.Project).Distinct().ToList();
    }
}