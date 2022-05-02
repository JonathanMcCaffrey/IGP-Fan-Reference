using Model.Entity.Data;
using Services.Website;

namespace Services.Immortal;

public class ImmortalSelectionService : IImmortalSelectionService, IDisposable
{
    private readonly IStorageService _storageService;
    private string _selectedFaction = DataType.FACTION_QRath;
    private string _selectedImmortal = DataType.IMMORTAL_Orzum;

    public ImmortalSelectionService(IStorageService storageService)
    {
        _storageService = storageService;

        _storageService.Subscribe(RefreshDefaults);

        RefreshDefaults();
    }

    void IDisposable.Dispose()
    {
        _storageService.Unsubscribe(RefreshDefaults);
    }

    public void Subscribe(Action action)
    {
        OnChange += action;
    }

    public void Unsubscribe(Action action)
    {
        OnChange -= action;
    }

    public string GetFaction()
    {
        return _selectedFaction;
    }

    public string GetImmortal()
    {
        return _selectedImmortal;
    }

    public bool SelectFaction(string faction)
    {
        if (_selectedFaction == faction) return false;
        _selectedFaction = faction;

        if (_selectedFaction == DataType.FACTION_QRath) _selectedImmortal = DataType.IMMORTAL_Orzum;

        if (_selectedFaction == DataType.FACTION_Aru) _selectedImmortal = DataType.IMMORTAL_Mala;

        NotifyDataChanged();
        return true;
    }

    public bool SelectImmortal(string immortal)
    {
        if (_selectedImmortal == immortal) return false;
        _selectedImmortal = immortal;
        NotifyDataChanged();
        return true;
    }

    private void RefreshDefaults()
    {
        var foundFaction = _storageService.GetValue<string?>(StorageKeys.SelectedFaction);
        var foundImmortal = _storageService.GetValue<string?>(StorageKeys.SelectedImmortal);

        if (foundFaction != null) _selectedFaction = foundFaction;

        if (foundImmortal != null) _selectedImmortal = foundImmortal;

        NotifyDataChanged();
    }

    private event Action OnChange = null!;

    private void NotifyDataChanged()
    {
        OnChange?.Invoke();
    }
}