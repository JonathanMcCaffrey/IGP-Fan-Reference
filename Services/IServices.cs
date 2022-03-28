using Contexts;
using Microsoft.EntityFrameworkCore;
using Model.Immortal.BuildOrders;
using Model.Immortal.Economy;
using Model.Immortal.Entity;
using Model.Immortal.MemoryTester;
using Model.Website;
using Model.Website.Enums;
using Model.Work.Git;
using Model.Work.Tasks;
using Services.Immortal;

namespace Services;

public interface IAgileService {
    public DbSet<SprintModel> SprintModels { get; }
    public DbSet<TaskModel> TaskModels { get; }
    public void Subscribe(Action action);
    public void Unsubscribe(Action action);
    public void Update();
    public Task Load(DatabaseContext database);
    public bool IsLoaded();
}

public interface IWebsiteService {
    public DbSet<WebPageModel> WebPageModels { get; }
    public DbSet<WebSectionModel> WebSectionModels { get; }
    public void Subscribe(Action action);
    public void Unsubscribe(Action action);
    public void Update();
    public Task Load(DatabaseContext database);
    public bool IsLoaded();
}

public interface IGitService {
    public DbSet<ChangeModel> ChangeModels { get; }
    public DbSet<PatchModel> PatchModels { get; }

    public void Subscribe(Action action);
    public void Unsubscribe(Action action);
    public void Update();
    public Task Load(DatabaseContext database);
    public bool IsLoaded();
}

public interface INavigationService {
    public void Subscribe(Action action);
    public void Unsubscribe(Action action);

    public void ChangeNavigationState(string newState);
    public string GetNavigationState();

    public void Back();
    public void SelectSection(int webSectionType);
    public void SelectPage(int pageType, Type webPageType);

    public NavSelectionType GetNavSelectionType();
    public int GetWebPageId();
    public int GetWebSectionId();
    public Type GetRenderType();
}

public interface IBuildComparisonService {
    public void SetBuilds(BuildComparisonModel buildComparison);
    public BuildComparisonModel Get();
    public string BuildOrderAsYaml();
    public string AsJson();
    public bool LoadJson(string data);
    public void Subscribe(Action action);
    public void Unsubscribe(Action action);
}

public interface ITimingService {
    public int GetTiming();
    public void SetTiming(int timing);
    public void Subscribe(Action action);
    public void Unsubscribe(Action action);
}

public interface IEconomyService {
    public List<EconomyModel> GetOverTime();
    public EconomyModel GetEconomy(int atInterval);
    public void Calculate(IBuildOrderService buildOrder, ITimingService timing, int fromInterval);
    public void Subscribe(Action action);
    public void Unsubscribe(Action action);
}

public interface IEntityFilterService {
    public delegate void EntityFilterAction(EntityFilterEvent entityFilterEvent);

    public string GetFactionType();
    public string GetImmortalType();
    public string GetEntityType();
    public string GetSearchText();

    public List<string> GetFactionChoices();
    public List<string> GetImmortalChoices();
    public List<string> GetEntityChoices();


    public bool SelectFactionType(string factionType);
    public bool SelectImmortalType(string immortalType);
    public bool SelectEntityType(string entityType);
    public bool EnterSearchText(string searchText);


    public void Subscribe(EntityFilterAction action);
    public void Unsubscribe(EntityFilterAction action);
}

public interface IEntityService {
    public List<EntityModel> GetEntities();
}

public interface IImmortalSelectionService {
    public string GetFactionType();
    public string GetImmortalType();
    public bool SelectFactionType(string factionType);
    public bool SelectImmortalType(string immortalType);
    public void Subscribe(Action action);
    public void Unsubscribe(Action action);
}

public interface IKeyService {
    public List<string> GetAllPressedKeys();
    public string GetHotkey();
    public string GetHotkeyGroup();
    public bool IsHoldingSpace();
    public bool AddPressedKey(string key);
    public bool RemovePressedKey(string key);
    public void Subscribe(Action action);
    public void Unsubscribe(Action action);
}

public interface IMemoryTesterService {
    public delegate void MemoryAction(MemoryTesterEvent memoryEvent);

    public List<MemoryEntityModel> GetEntities();
    public List<MemoryQuestionModel> GetQuestions();

    void GenerateQuiz();

    public void Update(MemoryQuestionModel question);

    public void Verify();

    public void Subscribe(MemoryAction memoryAction);
    public void Unsubscribe(MemoryAction memoryAction);
}

public interface IBuildOrderService {
    public bool Add(EntityModel entity, IEconomyService withEconomy);
    public void Add(EntityModel entity, int atInterval);

    public void SetName(string Name);
    public string GetName();

    public void SetNotes(string Notes);
    public string GetNotes();

    public void SetColor(string Color);
    public string GetColor();

    public bool MeetsRequirements(EntityModel entity, int interval);
    public Dictionary<int, List<EntityModel>> GetOrders();
    public List<EntityModel> GetOrdersAt(int interval);
    public List<EntityModel> GetCompletedAt(int interval);
    public List<EntityModel> GetCompletedBefore(int interval);
    public List<EntityModel> GetHarvestersCompletedBefore(int interval);

    public void RemoveLast();

    public int GetLastRequestInterval();
    public string BuildOrderAsYaml();
    public string AsJson();
    public void Subscribe(Action action);
    public void Unsubscribe(Action action);
}