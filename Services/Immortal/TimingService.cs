using Services.Website;

namespace Services.Immortal;

public class TimingService : ITimingService, IDisposable
{
    private readonly IStorageService _storageService;
    private int attackTime = 1500;
    private int travelTime = 30;

    public TimingService(IStorageService storageService)
    {
        _storageService = storageService;

        _storageService.Subscribe(RefreshDefaults);

        RefreshDefaults();
    }

    void IDisposable.Dispose()
    {
        _storageService.Unsubscribe(RefreshDefaults);
    }

    public void Subscribe(Action? action)
    {
        OnChange += action;
    }

    public void Unsubscribe(Action? action)
    {
        OnChange -= action;
    }

    public int BuildingInputDelay { get; set; } = 2;
    public int WaitTime { get; set; } = 30;
    public int WaitTo { get; set; } = 60;

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

    private void RefreshDefaults()
    {
        //TODO Timing has changed in Storage
        //TODO Timing has changed in itself

        var foundAttackTime = _storageService.GetValue<int?>(StorageKeys.AttackTime);
        var foundTravelTime = _storageService.GetValue<int?>(StorageKeys.TravelTime);

        var foundBuildInputDefault = _storageService.GetValue<int?>(StorageKeys.BuildInputDelay);

        var foundWaitTime = _storageService.GetValue<int?>(StorageKeys.WaitTime);
        var foundWaitTo = _storageService.GetValue<int?>(StorageKeys.WaitTo);

        if (foundAttackTime != null) attackTime = (int)foundAttackTime;
        if (foundTravelTime != null) travelTime = (int)foundTravelTime;

        if (foundBuildInputDefault != null) BuildingInputDelay = (int)foundBuildInputDefault;
        if (foundWaitTime != null) WaitTime = (int)foundWaitTime;
        if (foundWaitTo != null) WaitTo = (int)foundWaitTo;

        NotifyDataChanged();
    }

    private event Action? OnChange;

    private void NotifyDataChanged()
    {
        OnChange?.Invoke();
    }
}