using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Work.Tasks.Enums;

namespace Model.Work.Tasks;

public class AgileSprintModel
{
    public int Id { get; set; }
    public string Name { get; set; } = "Add name...";
    public string Description { get; set; } = "Add description...";

    public DateTime? StartDate { get; set; } = null;
    public DateTime? EndDate { get; set; } = null;

    public string Notes { get; set; } = "Add notes...";

    [NotMapped] public virtual ICollection<AgileTaskModel> AgileTaskModels { get; set; } = new List<AgileTaskModel>();


    public string GetSprintType()
    {
        var now = DateTime.Now;

        if (StartDate == null || EndDate == null) return SprintType.Planned;

        if (DateTime.Compare(now, EndDate.GetValueOrDefault()) > 0) return SprintType.Completed;
        if (DateTime.Compare(now, StartDate.GetValueOrDefault()) >= 0) return SprintType.Current;

        return SprintType.Planned;
    }
}