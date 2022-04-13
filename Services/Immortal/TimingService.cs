namespace Services.Immortal;

public class TimingService : ITimingService {
    private int _timing = 1500;

    public void Subscribe(Action? action) {
        _onChange += action;
    }

    public void Unsubscribe(Action? action) {
        _onChange -= action;
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

    private event Action? _onChange;

    private void NotifyDataChanged() {
        _onChange?.Invoke();
    }

    public Action? OnChange() {
        return _onChange;
    }
}