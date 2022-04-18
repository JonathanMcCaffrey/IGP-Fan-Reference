using System;
using System.Collections.Generic;
using System.Linq;
using Model.BuildOrders;
using Model.Entity;
using Model.Types;

namespace Model.Economy;

public class EconomyOverTimeModel
{
    public int LastInterval { get; set; }

    public List<EconomyModel> EconomyOverTime { get; set; } = new();
}