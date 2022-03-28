﻿using System.Net.Http.Json;
using Contexts;
using Microsoft.EntityFrameworkCore;
using Model.Work.Tasks;

namespace Services.Work;

public class AgileService : IAgileService {
    private readonly HttpClient httpClient;

    private bool isLoaded;

    public AgileService(HttpClient httpClient) {
        this.httpClient = httpClient;
    }

    private DatabaseContext Database { get; set; }
    public DbSet<SprintModel> SprintModels => Database.SprintModels;
    public DbSet<TaskModel> TaskModels => Database.TaskModels;

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

        Database.SprintModels.AddRange(await httpClient.GetFromJsonAsync<SprintModel[]>("generated/SprintModels.json"));
        Database.TaskModels.AddRange(await httpClient.GetFromJsonAsync<TaskModel[]>("generated/TaskModels.json"));

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