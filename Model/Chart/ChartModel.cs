using System.Collections.Generic;
using Model.Immortal.Chart.Enums;

namespace Model.Immortal.Chart;

public class ChartModel {
    public List<PointModel> Points { get; set; } = new();
    public string ChartColor { get; set; } = ChartColorType.Red.ToString();

    public int Offset { get; set; } = 0;
    public int IntervalDisplayMax { get; set; } = 300;
    public int ValueDisplayMax { get; set; } = 5000;

    public float HighestIntervalPoint { get; set; } = 5000;
    public float HighestValuePoint { get; set; } = 5000;

    public static List<ChartModel> GetAll() {
        var cs = new List<ChartModel>();

        var c1 = new ChartModel {
            IntervalDisplayMax = 1000,
            ValueDisplayMax = 300,
            ChartColor = "Orange",
            Points = new List<PointModel>()
        };

        for (var i = 0; i < c1.IntervalDisplayMax; i++)
            c1.Points.Add(new PointModel
                { Interval = i, Value = (int)(i / (float)c1.IntervalDisplayMax * c1.ValueDisplayMax) });

        cs.Add(c1);

        return cs;
    }
}