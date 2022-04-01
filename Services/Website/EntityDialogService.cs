using Model.Immortal.Entity;

namespace Services.Website;

//TODO Move to a database folder, with EntityService, EntityFilterService
public class EntityDialogService : IEntityDialogService
{
    private string? entityId = null;

    private List<string> history = new List<string>();
    
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
        history.Add(id);

        NotifyDataChanged();
    }

    public void CloseDialog()
    {
        entityId = null;
        history.Clear();
        
        NotifyDataChanged();
    }

    public void BackDialog()
    {
        if (history.Count > 1)
        {
            history.RemoveAt(history.Count - 1);
            
            if (history.Count == 0)
            {
                entityId = null;
                NotifyDataChanged();
                
                return;
            }
            
            entityId = history.Last();
            NotifyDataChanged();
        }
    }
    

    public bool HasDialog()
    {
        return entityId != null;
    }

    public bool HasHistory()
    {
        return history.Count > 1;
    }

    public string? GetEntityId()
    {
        return entityId;
    }
}


