namespace IGP.Utils;

public static class Interval
{
    public static string ToTime(int interval)
    {
        return TimeSpan.FromSeconds(interval).ToString(@"mm\:ss");
    }
}