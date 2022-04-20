using System.Collections.Generic;

namespace Model.Economy;

public class EconomyOverTimeModel
{
    public int LastInterval { get; set; }

    public List<EconomyModel> EconomyOverTime { get; set; } = new();
}