using System.Net.Http.Json;
using Contexts;
using Microsoft.EntityFrameworkCore;
using Model.Website;

namespace Services.Work;

public class WebsiteService : IWebsiteService {
    private readonly HttpClient httpClient;

    private bool isLoaded;

    public WebsiteService(HttpClient httpClient) {
        this.httpClient = httpClient;
    }

    private DatabaseContext Database { get; set; }
    public DbSet<WebSectionModel> WebSectionModels => Database.WebSectionModels;
    public DbSet<WebPageModel> WebPageModels => Database.WebPageModels;

    public void Subscribe(Action action) {
        _onChange += action;
    }

    public void Unsubscribe(Action action) {
        _onChange -= action;
    }

    public bool IsLoaded() {
        return isLoaded;
    }

    public async Task Load(DatabaseContext database) {
        Database = database;

        if (isLoaded) return;

        Database.WebPageModels.AddRange(await httpClient.GetFromJsonAsync<WebPageModel[]>("generated/WebPageModels.json"));
        Database.WebSectionModels.AddRange(
            await httpClient.GetFromJsonAsync<WebSectionModel[]>("generated/WebSectionModels.json"));

        Database.SaveChanges();

        isLoaded = true;

        NotifyDataChanged();
    }

    public void Update() {
        NotifyDataChanged();
    }

    private event Action _onChange;

    private void NotifyDataChanged() {
        _onChange?.Invoke();
    }
}