using System.Net.Http.Json;
using Contexts;
using Microsoft.EntityFrameworkCore;
using Model.Work.Git;

namespace Services.Work;

public class GitService : IGitService {
    private readonly HttpClient httpClient;

    private bool isLoaded;

    public GitService(HttpClient httpClient) {
        this.httpClient = httpClient;
    }

    public DatabaseContext Database { get; set; }
    public DbSet<ChangeModel> ChangeModels => Database.ChangeModels;
    public DbSet<PatchModel> PatchModels => Database.PatchModels;

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

        Database.ChangeModels.AddRange(await httpClient.GetFromJsonAsync<ChangeModel[]>("generated/ChangeModels.json"));
        Database.PatchModels.AddRange(await httpClient.GetFromJsonAsync<PatchModel[]>("generated/PatchModels.json"));
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