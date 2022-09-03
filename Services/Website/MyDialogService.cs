using Microsoft.AspNetCore.Components;

namespace Services.Website;

public class DialogContents
{
    public string Title { get; set; }
    public string Message { get; set; }
    public string ConfirmButtonLabel { get; set; }
    public EventCallback<EventArgs> OnConfirm { get; set; }
    public EventCallback<EventArgs> OnCancel { get; set; }
}

public class MyDialogService : IMyDialogService
{
    private DialogContents _dialogContents;

    public bool IsVisible { get; set; }

    public void Subscribe(Action action)
    {
        OnChange += action;
    }

    public void Unsubscribe(Action action)
    {
        OnChange += action;
    }

    public void Show(DialogContents dialogContents)
    {
        _dialogContents = dialogContents;
        IsVisible = true;

        NotifyDataChanged();
    }

    public DialogContents GetDialogContents()
    {
        return _dialogContents;
    }

    public void Hide()
    {
        IsVisible = false;

        NotifyDataChanged();
    }

    private event Action OnChange = null!;

    private void NotifyDataChanged()
    {
        OnChange();
    }
}