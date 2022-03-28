namespace Model.Immortal.Entity.Parts;

public class EntityPyreRewardModel : IEntityPartInterface {
    public string Type { get; set; } = "EntityPyreRewardModel";

    public int BaseReward { get; set; } = 0;
    public float OverTimeReward { get; set; } = 0;
    public int OverTimeRewardDuration { get; set; } = 0;
}