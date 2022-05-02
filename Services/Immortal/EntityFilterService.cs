using Model.Entity.Data;
using static Services.IEntityFilterService;

namespace Services.Immortal;

public enum EntityFilterEvent
{
    OnRefreshFaction,
    OnRefreshImmortal,
    OnRefreshEntity,
    OnRefreshSearch
}

public class EntityFilterService : IEntityFilterService
{
    private readonly List<string> _entityChoices = new();

    private readonly List<string> _factionChoices = new()
        { DataType.Any, DataType.FACTION_QRath, DataType.FACTION_Aru };

    private readonly List<string> _immortalChoices = new();
    private string _entityType = EntityType.Army;
    private string _searchText = "";
    private string _selectedFaction = DataType.Any;
    private string _selectedImmortal = DataType.Any;

    public EntityFilterService()
    {
        RefreshImmortalChoices();
        RefreshEntityChoices();
    }

    public void Subscribe(EntityFilterAction action)
    {
        OnChange += action;
    }

    public void Unsubscribe(EntityFilterAction action)
    {
        OnChange -= action;
    }

    public string GetEntityType()
    {
        return _entityType;
    }

    public string GetFactionType()
    {
        return _selectedFaction;
    }

    public string GetImmortalType()
    {
        return _selectedImmortal;
    }


    public bool SelectFactionType(string factionType)
    {
        if (_selectedFaction == factionType)
        {
            _selectedFaction = DataType.None;
            _selectedImmortal = DataType.None;

            RefreshImmortalChoices();
            RefreshEntityChoices();

            NotifyDataChanged(EntityFilterEvent.OnRefreshFaction);

            return true;
        }

        _selectedFaction = factionType;
        _selectedImmortal = DataType.Any;

        RefreshImmortalChoices();
        RefreshEntityChoices();

        NotifyDataChanged(EntityFilterEvent.OnRefreshFaction);
        return true;
    }

    public bool SelectImmortalType(string immortalType)
    {
        if (_selectedImmortal == immortalType)
        {
            _selectedImmortal = DataType.None;
            NotifyDataChanged(EntityFilterEvent.OnRefreshImmortal);
            return true;
        }

        _selectedImmortal = immortalType;
        NotifyDataChanged(EntityFilterEvent.OnRefreshImmortal);
        return true;
    }

    public bool SelectEntityType(string entityType)
    {
        if (_entityType == entityType) return false;
        _entityType = entityType;
        NotifyDataChanged(EntityFilterEvent.OnRefreshEntity);
        return true;
    }

    public bool EnterSearchText(string searchText)
    {
        if (_searchText.Equals(searchText))
            return false;
        _searchText = searchText;
        NotifyDataChanged(EntityFilterEvent.OnRefreshSearch);
        return true;
    }

    public List<string> GetFactionChoices()
    {
        return _factionChoices;
    }

    public List<string> GetImmortalChoices()
    {
        return _immortalChoices;
    }

    public List<string> GetEntityChoices()
    {
        return _entityChoices;
    }

    public string GetSearchText()
    {
        return _searchText;
    }

    private event EntityFilterAction OnChange = null!;

    private void RefreshImmortalChoices()
    {
        _immortalChoices.Clear();

        //TODO Consider getting these values from the database
        /*if (_selectedFaction == FactionType.QRath || _selectedFaction == FactionType.Any) {
            _immortalChoices.Add(ImmortalType.Orzum);
            _immortalChoices.Add(ImmortalType.Ajari);
        }

        if (_selectedFaction == FactionType.Aru || _selectedFaction == FactionType.Any) {
            _immortalChoices.Add(ImmortalType.Mala);
            _immortalChoices.Add(ImmortalType.Xol);
        }*/

        if (_selectedFaction == DataType.FACTION_QRath || _selectedFaction == DataType.Any)
        {
            _immortalChoices.Add(DataType.IMMORTAL_Orzum);
            _immortalChoices.Add(DataType.IMMORTAL_Ajari);
        }

        if (_selectedFaction == DataType.FACTION_Aru || _selectedFaction == DataType.Any)
        {
            _immortalChoices.Add(DataType.IMMORTAL_Mala);
            _immortalChoices.Add(DataType.IMMORTAL_Xol);
        }
    }

    private void RefreshEntityChoices()
    {
        _entityChoices.Clear();

        if (_selectedFaction == DataType.FACTION_QRath || _selectedFaction == DataType.FACTION_Aru ||
            _selectedFaction == DataType.Any)
        {
            _entityChoices.Add(EntityType.Army);
            _entityChoices.Add(EntityType.Immortal);
            _entityChoices.Add(EntityType.Passive);
            _entityChoices.Add(EntityType.Building);
            _entityChoices.Add(EntityType.Tech);
            _entityChoices.Add(EntityType.Ability);
            _entityChoices.Add(EntityType.Pyre_Spell);
            _entityChoices.Add(EntityType.Worker);
        }

        if (_selectedFaction == DataType.Any) _entityChoices.Add(EntityType.Any);
    }


    private void NotifyDataChanged(EntityFilterEvent entityFilterEvent)
    {
        OnChange?.Invoke(entityFilterEvent);
    }

    public void Subscribe(Action action)
    {
        throw new NotImplementedException();
    }

    public void Unsubscribe(Action action)
    {
        throw new NotImplementedException();
    }
}