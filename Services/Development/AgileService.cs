

using System.Net.Http.Json;
using Contexts;
using Microsoft.EntityFrameworkCore;
using Model.Work.Tasks;

namespace Services.Development;

public class AgileService : IAgileService {
    private readonly HttpClient httpClient;

    private bool isLoaded;
    
    private event Action OnChange = default!;

    public AgileService(HttpClient httpClient) {
        this.httpClient = httpClient;
    }


#if NO_SQL
    public List<AgileSprintModel>? AgileSprintModels { get; set; }
    public List<AgileTaskModel>? AgileTaskModels { get; set; }
#else

    private DatabaseContext Database { get; set; }
    public DbSet<SprintModel> SprintModels => Database.SprintModels;
    public DbSet<TaskModel> TaskModels => Database.TaskModels;
#endif


    public void Subscribe(Action? action) {
        OnChange += action;
    }

    public void Unsubscribe(Action? action) {
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

        AgileSprintModels = (await httpClient.GetFromJsonAsync<AgileSprintModel[]>("generated/AgileSprintModels.json")?? Array.Empty<AgileSprintModel>() ).ToList();
        AgileTaskModels = (await httpClient.GetFromJsonAsync<AgileTaskModel[]>("generated/AgileTaskModels.json") ?? Array.Empty<AgileTaskModel>()).ToList();
        
        foreach (var agileTask in AgileTaskModels)
        {
            if (agileTask.AgileSprintModelId != null)
            {
                SprintById(agileTask.AgileSprintModelId.Value)?.AgileTaskModels.Add(agileTask);
            }
        }
        
        isLoaded = true;

        NotifyDataChanged();
    }
    
    private AgileSprintModel? SprintById(int id)
    {
        foreach (var data in AgileSprintModels!)
            if (data.Id == id)
                return data;

        return null;
    }
    
    private AgileTaskModel? TaskById(int id)
    {
        foreach (var data in AgileTaskModels!)
            if (data.Id == id)
                return data;

        return null;
    }
    
#else
    public async Task Load(DatabaseContext database) {
        Database = database;

        if (isLoaded) {
            return;
        }

        Database.SprintModels.AddRange(await httpClient.GetFromJsonAsync<SprintModel[]>("generated/AgileSprintModels.json"));
        Database.TaskModels.AddRange(await httpClient.GetFromJsonAsync<TaskModel[]>("generated/AgileTaskModels.json"));

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