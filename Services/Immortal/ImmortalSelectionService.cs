using Model.Types;

namespace Services.Immortal;

public class ImmortalSelectionService : IImmortalSelectionService {
    private string _selectedFaction = FactionType.QRath;
    private string _selectedImmortal = ImmortalType.Orzum;

    public void Subscribe(Action action) {
        OnChange += action;
    }

    public void Unsubscribe(Action action) {
        OnChange -= action;
    }

    public string GetFactionType() {
        return _selectedFaction;
    }

    public string GetImmortalType() {
        return _selectedImmortal;
    }

    public bool SelectFactionType(string factionType) {
        if (_selectedFaction == factionType) return false;
        _selectedFaction = factionType;

        if (_selectedFaction == FactionType.QRath) _selectedImmortal = ImmortalType.Orzum;

        if (_selectedFaction == FactionType.Aru) _selectedImmortal = ImmortalType.Mala;

        NotifyDataChanged();
        return true;
    }

    public bool SelectImmortalType(string immortalType) {
        if (_selectedImmortal == immortalType) return false;
        _selectedImmortal = immortalType;
        NotifyDataChanged();
        return true;
    }

    private event Action OnChange = null!;

    private void NotifyDataChanged() {
        OnChange?.Invoke();
    }

}