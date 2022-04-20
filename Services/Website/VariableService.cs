using System.Net.Http.Json;
using Model;

namespace Services.Website;

public class VariableService : IVariableService
{
    private readonly HttpClient httpClient;

    private bool isLoaded;


    public VariableService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public Dictionary<string, string> Variables { get; set; } = new();

    public bool IsLoaded()
    {
        return isLoaded;
    }

    public async Task Load()
    {
        if (isLoaded) return;

        var variables = (await httpClient.GetFromJsonAsync<Variable[]>("generated/Variables.json"))!
            .ToList();

        foreach (var variable in variables) Variables.Add(variable.Key, variable.Value);

        isLoaded = true;
    }
}