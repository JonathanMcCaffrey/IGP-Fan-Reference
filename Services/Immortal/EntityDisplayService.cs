using Services.Website;

namespace Services.Immortal;

public class EntityViewType
{
    public static string Detailed = "Detailed";
    public static string Plain = "Plain";
}

public class EntityDisplayService : IEntityDisplayService
{
    private string _displayType;

    public EntityDisplayService(IStorageService storageService)
    {
        _displayType = storageService.GetValue<bool>(StorageKeys.IsPlainView)
            ? EntityViewType.Plain
            : EntityViewType.Detailed;
    }


    public List<string> DefaultChoices()
    {
        return new List<string> { EntityViewType.Detailed, EntityViewType.Plain };
    }

    public void Subscribe(Action action)
    {
        OnChange += action;
    }

    public void Unsubscribe(Action action)
    {
        OnChange -= action;
    }

    public string GetDisplayType()
    {
        return _displayType;
    }

    public void SetDisplayType(string displayType)
    {
        _displayType = displayType;
        NotifyDataChanged();
    }

    private event Action OnChange = null!;

    private void NotifyDataChanged()
    {
        OnChange?.Invoke();
    }
}