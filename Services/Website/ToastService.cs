using Model.Feedback;

namespace Services.Website;

public class ToastService : IToastService
{
    private readonly List<ToastModel> toasts = new();
    
    private event Action OnChange = null!;

    #if DEBUG
    public ToastService()
    {
        toasts.Add(new ToastModel(){Message = "Example message", SeverityType = SeverityType.Error, Title = "Example Error"});
        toasts.Add(new ToastModel(){Message = "Example message", SeverityType = SeverityType.Information, Title = "Example Information"});
        toasts.Add(new ToastModel(){Message = "Example message", SeverityType = SeverityType.Success, Title = "Example Success"});
        toasts.Add(new ToastModel(){Message = "Example message", SeverityType = SeverityType.Warning, Title = "Example Warning"});
    }
    #endif


    private void NotifyDataChanged() {
        OnChange();
    }
    
    public void Subscribe(Action action) {
        OnChange += action;
    }

    public void Unsubscribe(Action action) {
        OnChange += action;
    }

    public void AddToast(ToastModel toast)
    {
        toasts.Add(toast);
        NotifyDataChanged();
    }

    public void RemoveToast(ToastModel toast)
    {
        toasts.Remove(toast);
        NotifyDataChanged();
    }

    public bool HasToasts()
    {
        return toasts.Count > 0;
    }

    public List<ToastModel> GetToasts()
    {
        return toasts;
    }

    public void ClearAllToasts()
    {
        toasts.Clear();
        NotifyDataChanged();
    }

}


