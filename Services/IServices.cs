using Model.BuildOrders;
using Model.Doc;
using Model.Economy;
using Model.Entity;
using Model.Feedback;
using Model.Git;
using Model.MemoryTester;
using Model.Notes;
using Model.Website;
using Model.Website.Enums;
using Model.Work.Tasks;
using Services.Immortal;

namespace Services;

public interface IToastService
{
    public void Subscribe(Action action);
    public void Unsubscribe(Action action);
    void AddToast(ToastModel toast);
    void RemoveToast(ToastModel toast);
    bool HasToasts();
    List<ToastModel> GetToasts();
    void AgeToasts();
    void ClearAllToasts();
}

public interface IStorageService
{
    public void Subscribe(Action action);
    public void Unsubscribe(Action action);
    T GetValue<T>(string forKey);
    void SetValue<T>(string key, T value);

    Task Load();
}

public interface IPermissionService
{
    public void Subscribe(Action action);
    public void Unsubscribe(Action action);

    public bool GetIsStorageEnabled();
    public bool GetIsDataCollectionEnabled();

    public void SetIsStorageEnabled(bool isEnabled);
    public void SetIsDataCollectionEnabled(bool isEnabled);

    Task Load();
}

public interface ISearchService
{
    public List<SearchPointModel> SearchPoints { get; set; }

    public Dictionary<string, List<SearchPointModel>> Searches { get; set; }

    public bool IsVisible { get; set; }

    public void Subscribe(Action action);
    public void Unsubscribe(Action action);

    public void Search(string entityId);

    public Task Load();

    public bool IsLoaded();
    void Show();
    void Hide();
}

public interface IVariableService
{
    public Dictionary<string, string> Variables { get; set; }
    public Task Load();
    public bool IsLoaded();
}

public interface IEconomyComparisonService
{
    public List<BuildToCompareModel> BuildsToCompare { get; set; }
    public void ChangeNumberOfTownHalls(int forPlayer, int toCount);
    public void ChangeTownHallTiming(int forPlayer, int forTownHall, int toTiming);
    public int GetTownHallCount(int forPlayer);
    public int GetTownHallBuildTime(int forPlayer, int forTownHall);

    public List<int> GetTownHallBuildTimes(int forPlayer);
    public void ChangeFaction(int forPlayer, string toFaction);
    public string GetFaction(int forPlayer);

    public void ChangeColor(int forPlayer, string toColor);
    public string GetColor(int forPlayer);
    public void Subscribe(Action action);
    public void Unsubscribe(Action action);
}

public interface IEntityDialogService
{
    public void Subscribe(Action action);
    public void Unsubscribe(Action action);

    public void AddDialog(string entityId);
    public void CloseDialog();

    public void BackDialog();

    public string? GetEntityId();

    public bool HasDialog();
    public bool HasHistory();
}

public interface IWebsiteService
{
    public List<WebPageModel> WebPageModels { get; set; }
    public List<WebSectionModel> WebSectionModels { get; set; }

    public void Subscribe(Action action);
    public void Unsubscribe(Action action);
    public void Update();


    public Task Load();

    public bool IsLoaded();
}

public interface IAgileService
{
#if NO_SQL
    public List<AgileSprintModel>? AgileSprintModels { get; set; }
    public List<AgileTaskModel>? AgileTaskModels { get; set; }
#else
    public DbSet<SprintModel> SprintModels { get; }
    public DbSet<TaskModel> TaskModels { get; }
#endif

    public void Subscribe(Action? action);
    public void Unsubscribe(Action? action);
    public void Update();

    public Task Load();
    public bool IsLoaded();
}

public interface INoteService
{
    public List<NoteContentModel> NoteContentModels { get; set; }
    public List<NoteConnectionModel> NoteConnectionModels { get; set; }
    public List<NoteSectionModel> NoteSectionModels { get; set; }
    public void Subscribe(Action action);
    public void Unsubscribe(Action action);
    public void Update();
    public Task Load();
    public bool IsLoaded();
}

public interface IDocumentationService
{
    public List<DocContentModel> DocContentModels { get; set; }
    public List<DocConnectionModel> DocConnectionModels { get; set; }
    public List<DocContentModel> DocContentModelsByPageOrder { get; set; }
    public List<DocSectionModel> DocSectionModels { get; set; }

    public void Subscribe(Action? action);
    public void Unsubscribe(Action? action);
    public void Update();
    public Task Load();
    public bool IsLoaded();
}

public interface IGitService
{
#if NO_SQL
    public List<GitChangeModel> GitChangeModels { get; set; }
    public List<GitPatchModel> GitPatchModels { get; set; }
#else
    public DbSet<ChangeModel> ChangeModels { get; }
    public DbSet<PatchModel> PatchModels { get; }
#endif


    public void Subscribe(Action action);
    public void Unsubscribe(Action action);
    public void Update();
#if NO_SQL
    public Task Load();
#else
    public Task Load(DatabaseContext database);
#endif
    public bool IsLoaded();
}

public interface INavigationService
{
    public void Subscribe(Action action);
    public void Unsubscribe(Action action);

    public void ChangeNavigationSectionId(int newState);
    public int GetNavigationSectionId();
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

public interface IBuildComparisonService
{
    public void SetBuilds(BuildToCompareModel buildToCompareModel);
    public BuildToCompareModel Get();
    public string BuildOrderAsYaml();
    public string AsJson();
    public bool LoadJson(string data);
    public void Subscribe(Action action);
    public void Unsubscribe(Action action);
}

public interface ITimingService
{
    public int BuildingInputDelay { get; set; }
    public int WaitTime { get; set; }
    public int WaitTo { get; set; }
    public int GetAttackTime();
    public void SetAttackTime(int timing);
    public int GetTravelTime();
    public void SetTravelTime(int timing);
    public void Subscribe(Action? action);
    public void Unsubscribe(Action? action);
}

public interface IEconomyService
{
    public List<EconomyModel> GetOverTime();
    public EconomyModel GetEconomy(int atInterval);
    public void Calculate(IBuildOrderService buildOrder, ITimingService timing, int fromInterval);
    public void Subscribe(Action action);
    public void Unsubscribe(Action action);
}

public interface IEntityFilterService
{
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

public interface IEntityService
{
    public List<EntityModel> GetEntities();
}

public interface IEntityDisplayService
{
    public List<string> DefaultChoices();

    public string GetDisplayType();
    public void SetDisplayType(string displayType);
    public void Subscribe(Action action);
    public void Unsubscribe(Action action);
}

public interface IImmortalSelectionService
{
    public string GetFaction();
    public string GetImmortal();
    public bool SelectFaction(string faction);
    public bool SelectImmortal(string immortal);
    public void Subscribe(Action action);
    public void Unsubscribe(Action action);
}

public interface IKeyService
{
    public List<string> GetAllPressedKeys();
    public string? GetHotkey();
    public string GetHotkeyGroup();
    public bool IsHoldingSpace();
    public bool AddPressedKey(string key);
    public bool RemovePressedKey(string key);
    public void Subscribe(Action? action);
    public void Unsubscribe(Action? action);
}

public interface IMemoryTesterService
{
    public delegate void MemoryAction(MemoryTesterEvent memoryEvent);

    public List<MemoryEntityModel> GetEntities();
    public List<MemoryQuestionModel> GetQuestions();

    void GenerateQuiz();

    public void Update(MemoryQuestionModel question);

    public void Verify();

    public void Subscribe(MemoryAction memoryAction);
    public void Unsubscribe(MemoryAction memoryAction);
}

public interface IBuildOrderService
{
    public Dictionary<int, List<EntityModel>> StartedOrders { get; }
    public Dictionary<int, List<EntityModel>> CompletedOrders { get; }
    public Dictionary<string, int> UniqueCompletedTimes { get; }

    public Dictionary<int, int> SupplyCountTimes { get; }


    public bool Add(EntityModel entity, IEconomyService withEconomy);
    public void Add(EntityModel entity, int atInterval);
    public bool AddWait(int forInterval);
    public bool AddWaitTo(int interval);


    public void SetName(string name);
    public string GetName();

    public void SetNotes(string notes);
    public string GetNotes();

    public void DeprecatedSetColor(string color);
    public string GetColor();

    public int? WillMeetRequirements(EntityModel entity);
    public int? WillMeetSupply(EntityModel entity);
    public Dictionary<int, List<EntityModel>> GetOrders();
    public List<EntityModel> GetCompletedBefore(int interval);
    public List<EntityModel> GetHarvestPointsCompletedBefore(int interval);

    public void RemoveLast();
    public void Reset();

    public int GetLastRequestInterval();
    public string BuildOrderAsYaml();
    public string AsJson();
    public void Subscribe(Action action);
    public void Unsubscribe(Action action);
}