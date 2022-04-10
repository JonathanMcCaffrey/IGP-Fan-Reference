using System.Net.Http.Json;
using Model.Git;

#if NO_SQL

#else
using Contexts;
using Microsoft.EntityFrameworkCore;
#endif

namespace Services.Development;

public class GitService : IGitService {
    private readonly HttpClient httpClient;

    private bool isLoaded;

    private event Action OnChange = default!;

    
    public GitService(HttpClient httpClient) {
        this.httpClient = httpClient;
    }

#if NO_SQL
    public List<GitChangeModel> GitChangeModels { get; set; } = default!;
    public List<GitPatchModel> GitPatchModels { get; set; } = default!;
#else
    public DbSet<ChangeModel> ChangeModels => Database.ChangeModels;
    public DbSet<PatchModel> PatchModels => Database.PatchModels;
    public DatabaseContext Database { get; set; }
#endif



    public void Subscribe(Action action) {
        OnChange += action;
    }

    public void Unsubscribe(Action action) {
        OnChange -= action;
    }

    public bool IsLoaded() {
        return isLoaded;
    }

    
#if NO_SQL

    public async Task Load() {

        if (isLoaded) {
            return;
        }
        
        GitChangeModels =  (await httpClient.GetFromJsonAsync<GitChangeModel[]>("generated/GitChangeModels.json") ?? Array.Empty<GitChangeModel>()).ToList();
        GitPatchModels = (await httpClient.GetFromJsonAsync<GitPatchModel[]>("generated/GitPatchModels.json") ?? Array.Empty<GitPatchModel>()).ToList();


        isLoaded = true;

        NotifyDataChanged();
    }

#else

    public async Task Load(DatabaseContext database) {
        Database = database;

        if (isLoaded) {
            return;
        }
        
        Database.ChangeModels.AddRange(await httpClient.GetFromJsonAsync<ChangeModel[]>("generated/GitChangeModels.json"));
        Database.PatchModels.AddRange(await httpClient.GetFromJsonAsync<PatchModel[]>("generated/GitPatchModels.json"));
        Database.SaveChanges();


        isLoaded = true;

        NotifyDataChanged();
    }

#endif

    
    public void Update() {
        NotifyDataChanged();
    }

    private void NotifyDataChanged() {
        OnChange?.Invoke();
    }
}