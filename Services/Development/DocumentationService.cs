using System.Net.Http.Json;
using Model.Documentation;

#if NO_SQL

#else
using Contexts;
using Microsoft.EntityFrameworkCore;
#endif

namespace Services.Development;

public class DocumentationService : IDocumentationService
{
    private readonly HttpClient httpClient;

    private bool isLoaded;
    
    
    private event Action _onChange;


    public DocumentationService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public List<DocumentationModel> DocumentationModels { get; set; }


    public void Subscribe(Action action)
    {
        _onChange += action;
    }

    public void Unsubscribe(Action action)
    {
        _onChange -= action;
    }

    public bool IsLoaded()
    {
        return isLoaded;
    }


    public async Task Load()
    {
        if (isLoaded) return;

        DocumentationModels =
            (await httpClient.GetFromJsonAsync<DocumentationModel[]>("generated/DocumentationModels.json") ?? Array.Empty<DocumentationModel>()).ToList();


        isLoaded = true;

        NotifyDataChanged();
    }


    public void Update()
    {
        NotifyDataChanged();
    }


    private void NotifyDataChanged()
    {
        _onChange?.Invoke();
    }
}