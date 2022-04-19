using System.Collections.Generic;
using Model.Entity;

namespace Model.Economy;

public class EconomyModel
{
    public int Interval { get; set; } = 0;
    public float Alloy { get; set; } = 0;
    public float Ether { get; set; } = 0;
    public float Pyre { get; set; } = 0;
    public int Supply { get; set; } = 0;
    public int WorkerCount { get; set; } = 6;
    public int BusyWorkerCount { get; set; } = 0;
    public int CreatingWorkerCount { get; set; } = 0;
    public List<int> CreatingWorkerDelays { get; set; } = new();
    public List<EntityModel> HarvestPoints { get; set; } = new();
}