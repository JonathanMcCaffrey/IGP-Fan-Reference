

using System.Net.Http.Json;
using Contexts;
using Microsoft.EntityFrameworkCore;
using Model.Work.Tasks;

namespace Services.Development;

public class AgileService : IAgileService {
    private readonly HttpClient httpClient;

    private bool isLoaded;

    
    private event Action _onChange;

    
    public AgileService(HttpClient httpClient) {
        this.httpClient = httpClient;
    }


#if NO_SQL
    public List<SprintModel> SprintModels { get; set; }
    public List<TaskModel> TaskModels { get; set; }
#else

    private DatabaseContext Database { get; set; }
    public DbSet<SprintModel> SprintModels => Database.SprintModels;
    public DbSet<TaskModel> TaskModels => Database.TaskModels;
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

        SprintModels = (await httpClient.GetFromJsonAsync<SprintModel[]>("generated/SprintModels.json")?? Array.Empty<SprintModel>() ).ToList();
        TaskModels =(await httpClient.GetFromJsonAsync<TaskModel[]>("generated/TaskModels.json") ?? Array.Empty<TaskModel>()).ToList();

        isLoaded = true;

        NotifyDataChanged();
    }
#else
    public async Task Load(DatabaseContext database) {
        Database = database;

        if (isLoaded) {
            return;
        }

        Database.SprintModels.AddRange(await httpClient.GetFromJsonAsync<SprintModel[]>("generated/SprintModels.json"));
        Database.TaskModels.AddRange(await httpClient.GetFromJsonAsync<TaskModel[]>("generated/TaskModels.json"));

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