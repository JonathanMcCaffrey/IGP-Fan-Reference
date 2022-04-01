using Model.Immortal.Entity;

namespace Services.Website;

public class EntityDialogService : IEntityDialogService
{
    private string? entityId = null;
    
    private event Action _onChange;

    private void NotifyDataChanged() {
        _onChange?.Invoke();
    }
    
    public void Subscribe(Action action) {
        _onChange += action;
    }

    public void Unsubscribe(Action action) {
        _onChange += action;
    }
    
    public void AddDialog(string id)
    {
        entityId = id;

        NotifyDataChanged();
    }

    public void CloseDialog()
    {
        entityId = null;
        
        NotifyDataChanged();
    }
    

    public bool HasDialog()
    {
        return entityId != null;
    }

    public string? GetEntityId()
    {
        return entityId;
    }
}


