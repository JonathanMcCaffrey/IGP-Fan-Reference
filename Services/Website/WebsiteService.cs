using System.Net.Http.Json;

#if !NO_SQL
using Contexts;
using Microsoft.EntityFrameworkCore;
#endif

using Model.Website;

namespace Services.Development;

public class WebsiteService : IWebsiteService {
    private readonly HttpClient httpClient;

    private bool isLoaded;

    
    private event Action _onChange;

    
    public WebsiteService(HttpClient httpClient) {
        this.httpClient = httpClient;
    }



#if NO_SQL
    public List<WebSectionModel> WebSectionModels { get; set; }
    public List<WebPageModel> WebPageModels { get; set; }
#else

    private DatabaseContext Database { get; set; }

    
    public DbSet<WebSectionModel> WebSectionModels => Database.WebSectionModels;
    public DbSet<WebPageModel> WebPageModels => Database.WebPageModels;
#endif


    public void Subscribe(Action action) {
        _onChange += action;
    }

    public void Unsubscribe(Action action) {
        _onChange -= action;
    }

    public bool IsLoaded() {
        return isLoaded;
    }
    
#if NO_SQL
    
    public async Task Load() {
        if (isLoaded) {return;}
        
        WebPageModels = (await httpClient.GetFromJsonAsync<WebPageModel[]>("generated/WebPageModels.json")).ToList();
        WebSectionModels =(await httpClient.GetFromJsonAsync<WebSectionModel[]>("generated/WebSectionModels.json")).ToList();

        isLoaded = true;

        NotifyDataChanged();
    }
#else
    public async Task Load(DatabaseContext database) {
        Database = database;

        if (isLoaded) {return;}

        Database.WebPageModels.AddRange(await httpClient.GetFromJsonAsync<WebPageModel[]>("generated/WebPageModels.json"));
        Database.WebSectionModels.AddRange(
            await httpClient.GetFromJsonAsync<WebSectionModel[]>("generated/WebSectionModels.json"));

        Database.SaveChanges();

        isLoaded = true;

        NotifyDataChanged();
    }    
#endif


    public void Update() {
        NotifyDataChanged();
    }

    private void NotifyDataChanged() {
        _onChange?.Invoke();
    }
}