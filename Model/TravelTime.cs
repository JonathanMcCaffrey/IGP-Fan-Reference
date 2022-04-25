namespace Model;

public class TravelTime
{
    public TravelTime(int index, float value)
    {
        Index = index;
        Value = value;
    }

    public int Index { get; set; }
    public float Value { get; set; }
}