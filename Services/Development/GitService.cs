

using System.Net.Http.Json;
using Model.Work.Git;

#if NO_SQL

#else
using Contexts;
using Microsoft.EntityFrameworkCore;
#endif

namespace Services.Work;

public class GitService : IGitService {
    private readonly HttpClient httpClient;

    private bool isLoaded;

    public GitService(HttpClient httpClient) {
        this.httpClient = httpClient;
    }

#if NO_SQL
    public List<ChangeModel> ChangeModels { get; set; }
    public List<PatchModel> PatchModels { get; set; }
#else
    public DbSet<ChangeModel> ChangeModels => Database.ChangeModels;
    public DbSet<PatchModel> PatchModels => Database.PatchModels;
    public DatabaseContext Database { get; set; }
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

        if (isLoaded) {
            return;
        }
        
        ChangeModels =  (await httpClient.GetFromJsonAsync<ChangeModel[]>("generated/ChangeModels.json")).ToList();
        PatchModels = (await httpClient.GetFromJsonAsync<PatchModel[]>("generated/PatchModels.json")).ToList();


        isLoaded = true;

        NotifyDataChanged();
    }

#else

    public async Task Load(DatabaseContext database) {
        Database = database;

        if (isLoaded) {
            return;
        }
        
        Database.ChangeModels.AddRange(await httpClient.GetFromJsonAsync<ChangeModel[]>("generated/ChangeModels.json"));
        Database.PatchModels.AddRange(await httpClient.GetFromJsonAsync<PatchModel[]>("generated/PatchModels.json"));
        Database.SaveChanges();


        isLoaded = true;

        NotifyDataChanged();
    }

#endif

    
    public void Update() {
        NotifyDataChanged();
    }

    private event Action _onChange;

    private void NotifyDataChanged() {
        _onChange?.Invoke();
    }
}