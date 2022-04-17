namespace Services.Immortal;

public class TimingService : ITimingService
{
    private int attackTime = 1500;
    private int travelTime = 30;

    public void Subscribe(Action? action)
    {
        OnChange += action;
    }

    public void Unsubscribe(Action? action)
    {
        OnChange -= action;
    }

    public int GetAttackTime()
    {
        return attackTime;
    }

    public void SetAttackTime(int timing)
    {
        if (attackTime != timing)
        {
            attackTime = timing;
            NotifyDataChanged();
        }
    }

    public int GetTravelTime()
    {
        return travelTime;
    }

    public void SetTravelTime(int timing)
    {
        if (travelTime != timing)
        {
            travelTime = timing;
            NotifyDataChanged();
        }
    }

    private event Action? OnChange;

    private void NotifyDataChanged()
    {
        OnChange?.Invoke();
    }
}