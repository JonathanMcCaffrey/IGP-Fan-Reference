namespace Services.Immortal;

public class TimingService : ITimingService {
    private int _timing = 1500;

    private event Action? OnChange;

    public void Subscribe(Action? action) {
        OnChange += action;
    }

    public void Unsubscribe(Action? action) {
        OnChange -= action;
    }

    public int GetTiming() {
        return _timing;
    }

    public void SetTiming(int timing) {
        if (_timing != timing) {
            _timing = timing;
            NotifyDataChanged();
        }
    }

    private void NotifyDataChanged() {
        OnChange?.Invoke();
    }

}