using Model.Entity.Data;
using Model.Website;

namespace Services.Website;

public class SearchService : ISearchService
{
    private readonly IDocumentationService documentationService;
    private readonly INoteService noteService;


    private readonly IWebsiteService websiteService;

    private bool isLoaded;

    public SearchService(IWebsiteService websiteService, INoteService noteService,
        IDocumentationService documentationService)
    {
        this.websiteService = websiteService;
        this.noteService = noteService;
        this.documentationService = documentationService;

        // All Unit Data
    }

    public List<SearchPointModel> SearchPoints { get; set; } = new();

    public Dictionary<string, List<SearchPointModel>> Searches { get; set; } = new();

    public bool IsVisible { get; set; }

    public void Subscribe(Action action)
    {
        OnChange += action;
    }

    public void Unsubscribe(Action action)
    {
        OnChange += action;
    }

    public void Search(string entityId)
    {
    }

    public async Task Load()
    {
        await websiteService.Load();
        await noteService.Load();
        await documentationService.Load();


        Searches.Add("Pages", new List<SearchPointModel>());
        Searches.Add("Notes", new List<SearchPointModel>());
        Searches.Add("Documents", new List<SearchPointModel>());
        Searches.Add("Entities", new List<SearchPointModel>());

        foreach (var webPage in websiteService.WebPageModels)
        {
            SearchPoints.Add(new SearchPointModel
            {
                Title = webPage.Name,
                PointType = "WebPage",
                 Summary = $"{webPage.Description}",
                Href = webPage.Href
            });

            Searches["Pages"].Add(SearchPoints.Last());
        }

        foreach (var note in noteService.NoteContentModels)
        {
            SearchPoints.Add(new SearchPointModel
            {
                Title = note.Name,
                PointType = "Note", Href = note.GetNoteLink()
            });

            Searches["Notes"].Add(SearchPoints.Last());
        }


        foreach (var entity in DATA.Get().Values)
        {
            SearchPoints.Add(new SearchPointModel
            {
                Title = entity.Info().Name,
                Tags = $"{entity.EntityType},{entity.Descriptive}",
                PointType = "Entity",
                Summary = $"{entity.EntityType}, {entity.Info().Description.Substring(0, Math.Min(30, entity.Info().Description.Length - 1))}",
                Href = $"database/{entity.Info().Name.ToLower()}"
            });

            Searches["Entities"].Add(SearchPoints.Last());
        }

        isLoaded = true;

        NotifyDataChanged();
    }

    public bool IsLoaded()
    {
        return isLoaded;
    }

    public void Show()
    {
        IsVisible = true;

        NotifyDataChanged();
    }

    public void Hide()
    {
        IsVisible = false;

        NotifyDataChanged();
    }

    private event Action OnChange = null!;

    private void NotifyDataChanged()
    {
        OnChange();
    }
}