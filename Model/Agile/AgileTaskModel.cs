using System;
using Model.Work.Tasks.Enums;

namespace Model.Work.Tasks;

public class AgileTaskModel
{
    public int Id { get; set; } = 1;
    public int? AgileSprintModelId { get; set; } = null;
    public string Name { get; set; } = "Add name...";
    public string Description { get; set; } = "Add description...";
    public string Notes { get; set; } = "Add notes...";
    public string Status { get; set; } = StatusType.Fun_Idea;
    public string Priority { get; set; } = PriorityType.Medium;
    public string Task { get; set; } = TaskType.Feature;
    
    public int OrderPriority => Status == StatusType.In_Progress ? 1
        : Status == StatusType.Todo ? 2
        : Status == StatusType.Done ? 3 
        : Status == StatusType.Canceled ? 4
        : Status == StatusType.To_Test ? 2 
        : Status == StatusType.Fun_Idea ? 5 : 6;

    public DateTime? Created { get; set; } = null;
    public DateTime? Finished { get; set; } = null;
}