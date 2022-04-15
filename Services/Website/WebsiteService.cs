using System.Net.Http.Json;
using Model.Website;

namespace Services.Development;

public class WebsiteService : IWebsiteService
{
    private readonly HttpClient httpClient;

    private bool isLoaded;


    public WebsiteService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }


    public List<WebSectionModel> WebSectionModels { get; set; } = default!;
    public List<WebPageModel> WebPageModels { get; set; } = default!;


    public void Subscribe(Action action)
    {
        OnChange += action;
    }

    public void Unsubscribe(Action action)
    {
        OnChange -= action;
    }

    public bool IsLoaded()
    {
        return isLoaded;
    }

    public async Task Load()
    {
        if (isLoaded) return;

        WebPageModels = (await httpClient.GetFromJsonAsync<WebPageModel[]>("generated/WebPageModels.json"))!.ToList();
        WebSectionModels = (await httpClient.GetFromJsonAsync<WebSectionModel[]>("generated/WebSectionModels.json"))!
            .ToList();

        isLoaded = true;

        SortSql();

        NotifyDataChanged();
    }

    public void Update()
    {
        NotifyDataChanged();
    }


    private event Action OnChange = default!;

    private void SortSql()
    {
        foreach (var page in WebPageModels)
            if (page.WebSectionModelId != null)
            {
                var webSection =
                    WebSectionModels.Find(webSection => webSection.Id == page.WebSectionModelId);

                webSection.WebPageModels.Add(page);
            }
    }

    private void NotifyDataChanged()
    {
        OnChange?.Invoke();
    }
}