namespace Model.Chart;

public class PointModel
{
    public float Interval { get; set; } = 0;
    public float Value { get; set; } = 0;
    public float TempValue { get; set; } = 0;

    public string GetInterval(float highestInterval, float displayScale)
    {
        var display = Interval / highestInterval * displayScale;
        return ((int)display).ToString();
    }


    public string GetValue(float highestValue, float displayScale)
    {
        var display = Value / highestValue * displayScale;
        return ((int)display).ToString();
    }
}