namespace Model;

public class TravelTime
{
    public TravelTime(int index, int value)
    {
        Index = index;
        Value = value;
    }

    public int Index { get; set; }
    public int Value { get; set; }
}