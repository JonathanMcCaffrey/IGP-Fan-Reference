using Model.Immortal.Entity.Data;
using Model.Immortal.Types;
using static Services.IEntityFilterService;

namespace Services.Immortal;

public enum EntityFilterEvent {
    OnRefreshFaction,
    OnRefreshImmortal,
    OnRefreshEntity,
    OnRefreshSearch
}

public class EntityFilterService : IEntityFilterService {
    private readonly List<string> _entityChoices = new();

    private readonly List<string> _factionChoices = new() { FactionType.QRath, FactionType.Aru, FactionType.Any };
    private readonly List<string> _immortalChoices = new();
    private string _entityType = EntityType.Army;
    private string _searchText = "";
    private string _selectedFaction = FactionType.QRath;
    private string _selectedImmortal = ImmortalType.Orzum;


    public EntityFilterService() {
        RefreshImmortalChoices();
        RefreshEntityChoices();
    }

    public void Subscribe(EntityFilterAction action) {
        _onChange += action;
    }

    public void Unsubscribe(EntityFilterAction action) {
        _onChange -= action;
    }

    public string GetEntityType() {
        return _entityType;
    }

    public string GetFactionType() {
        return _selectedFaction;
    }

    public string GetImmortalType() {
        return _selectedImmortal;
    }


    public bool SelectFactionType(string factionType) {
        if (_selectedFaction == factionType) {
            _selectedFaction = FactionType.None;
            _selectedImmortal = ImmortalType.None;

            RefreshImmortalChoices();
            RefreshEntityChoices();

            NotifyDataChanged(EntityFilterEvent.OnRefreshFaction);

            return true;
        }

        _selectedFaction = factionType;
        _selectedImmortal = ImmortalType.Any;

        RefreshImmortalChoices();
        RefreshEntityChoices();

        NotifyDataChanged(EntityFilterEvent.OnRefreshFaction);
        return true;
    }

    public bool SelectImmortalType(string immortalType) {
        if (_selectedImmortal == immortalType) {
            _selectedImmortal = ImmortalType.None;
            NotifyDataChanged(EntityFilterEvent.OnRefreshImmortal);
            return true;
        }

        _selectedImmortal = immortalType;
        NotifyDataChanged(EntityFilterEvent.OnRefreshImmortal);
        return true;
    }

    public bool SelectEntityType(string entityType) {
        if (_entityType == entityType) return false;
        _entityType = entityType;
        NotifyDataChanged(EntityFilterEvent.OnRefreshEntity);
        return true;
    }

    public bool EnterSearchText(string searchText) {
        if (_searchText.Equals(searchText))
            return false;
        _searchText = searchText;
        NotifyDataChanged(EntityFilterEvent.OnRefreshSearch);
        return true;
    }

    public List<string> GetFactionChoices() {
        return _factionChoices;
    }

    public List<string> GetImmortalChoices() {
        return _immortalChoices;
    }

    public List<string> GetEntityChoices() {
        return _entityChoices;
    }

    public string GetSearchText() {
        return _searchText;
    }

    private void RefreshImmortalChoices() {
        _immortalChoices.Clear();

        //TODO Consider getting these values from the database
        if (_selectedFaction == FactionType.QRath || _selectedFaction == FactionType.Any) {
            _immortalChoices.Add(ImmortalType.Orzum);
            _immortalChoices.Add(ImmortalType.Ajari);
        }

        if (_selectedFaction == FactionType.Aru || _selectedFaction == FactionType.Any) {
            _immortalChoices.Add(ImmortalType.Mala);
            _immortalChoices.Add(ImmortalType.Xol);
        }
    }

    private void RefreshEntityChoices() {
        _entityChoices.Clear();

        if (_selectedFaction == FactionType.QRath || _selectedFaction == FactionType.Aru) {
            _entityChoices.Add(EntityType.Army);
            _entityChoices.Add(EntityType.Immortal);
            _entityChoices.Add(EntityType.Passive);
            _entityChoices.Add(EntityType.Building);
            _entityChoices.Add(EntityType.Tech);
            _entityChoices.Add(EntityType.Ability);
            _entityChoices.Add(EntityType.Pyre_Spell);
            _entityChoices.Add(EntityType.Building_Upgrade);
            _entityChoices.Add(EntityType.Worker);
        }

        if (_selectedFaction == FactionType.Any) {
            _entityChoices.Add(EntityType.Teapot);
            _entityChoices.Add(EntityType.Command);
            _entityChoices.Add(EntityType.Pyre_Event);
            _entityChoices.Add(EntityType.Family);
            _entityChoices.Add(EntityType.Faction);
            _entityChoices.Add(EntityType.Any);
        }
    }


    private event EntityFilterAction _onChange;

    private void NotifyDataChanged(EntityFilterEvent entityFilterEvent) {
        _onChange?.Invoke(entityFilterEvent);
    }

    public EntityFilterAction OnChange() {
        return _onChange;
    }

    public void Subscribe(Action action) {
        throw new NotImplementedException();
    }

    public void Unsubscribe(Action action) {
        throw new NotImplementedException();
    }
}