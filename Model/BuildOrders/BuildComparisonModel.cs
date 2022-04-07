using System.Collections.Generic;

namespace Model.BuildOrders;

public class BuildComparisonModel
{
    public List<BuildOrderModel> Builds { get; set; } = new()
    {
        new BuildOrderModel(),
        new BuildOrderModel(),
        new BuildOrderModel()
    };
}