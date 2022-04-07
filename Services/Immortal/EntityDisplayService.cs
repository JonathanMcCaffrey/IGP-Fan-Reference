using Model.Types;

namespace Services.Immortal;

public class EntityDisplayService : IEntityDisplayService {
    private string displayType = "Detailed";
    private event Action OnChange = null!;

    public List<string> DefaultChoices()
    {
        return new List<string>() { "Detailed", "Plain" };
    }

    public void Subscribe(Action action) {
        OnChange += action;
    }

    public void Unsubscribe(Action action) {
        OnChange -= action;
    }

    private void NotifyDataChanged() {
        OnChange?.Invoke();
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