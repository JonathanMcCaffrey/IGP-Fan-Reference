using Model.Feedback;

namespace Services.Website;

public class ToastService : IToastService
{
    private readonly List<ToastModel> toasts = new();

    public void Subscribe(Action action)
    {
        OnChange += action;
    }

    public void Unsubscribe(Action action)
    {
        OnChange += action;
    }

    public void AddToast(ToastModel toast)
    {
        toasts.Insert(0, toast);

        NotifyDataChanged();
    }

    public void RemoveToast(ToastModel toast)
    {
        toasts.Remove(toast);
    }

    public bool HasToasts()
    {
        return toasts.Count > 0;
    }

    public List<ToastModel> GetToasts()
    {
        return toasts;
    }

    public void AgeToasts()
    {
        foreach (var toast in toasts) toast.Age++;

        NotifyDataChanged();
    }

    public void ClearAllToasts()
    {
        toasts.Clear();
        NotifyDataChanged();
    }

    private event Action OnChange = null!;

    private void NotifyDataChanged()
    {
        OnChange();
    }
}