using Model.Immortal.Types;

namespace Services.Immortal;

public class EntityDisplayService : IEntityDisplayService {
    private string displayType = "Detailed";
    private event Action _onChange;

    public List<string> DefaultChoices()
    {
        return new List<string>() { "Detailed", "Plain" };
    }

    public void Subscribe(Action action) {
        _onChange += action;
    }

    public void Unsubscribe(Action action) {
        _onChange -= action;
    }

    private void NotifyDataChanged() {
        _onChange?.Invoke();
    }

    public Action OnChange() {
        return _onChange;
    }

    public string GetDisplayType()
    {
        return displayType;
    }

    public void SetDisplayType(string displayType)
    {
        this.displayType = displayType;
        NotifyDataChanged();
    }

}