using System.ComponentModel.DataAnnotations;

namespace Model;

public class TravelTime
{
    public int Index { get; set; } = 0;
    public int Value { get; set; } = 0;

    public TravelTime(int index, int value)
    {
        Index = index;
        Value = value;
    }
}