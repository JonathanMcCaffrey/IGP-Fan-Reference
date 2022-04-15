using System.Net.Http.Json;
using Model.Doc;

namespace Services.Development;

public class DocumentationService : IDocumentationService
{
    private readonly HttpClient httpClient;
    private bool isLoaded;

    public DocumentationService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public List<DocContentModel> DocContentModels { get; set; } = new();

    public List<DocContentModel> DocContentModelsByPageOrder { get; set; } = new();

    public List<DocSectionModel> DocSectionModels { get; set; } = new();

    public List<DocConnectionModel> DocConnectionModels { get; set; } = new();


    public void Subscribe(Action? action)
    {
        OnChange += action;
    }

    public void Unsubscribe(Action? action)
    {
        OnChange -= action;
    }

    public bool IsLoaded()
    {
        return isLoaded;
    }


    public async Task Load()
    {
        if (isLoaded) return;

        DocContentModels =
            (await httpClient.GetFromJsonAsync<DocContentModel[]>("generated/DocContentModels.json") ??
             Array.Empty<DocContentModel>()).ToList();

        DocConnectionModels =
            (await httpClient.GetFromJsonAsync<DocConnectionModel[]>("generated/DocConnectionModels.json") ??
             Array.Empty<DocConnectionModel>()).ToList();

        DocSectionModels =
            (await httpClient.GetFromJsonAsync<DocSectionModel[]>("generated/DocSectionModels.json") ??
             Array.Empty<DocSectionModel>()).ToList();

        SortSql();

        isLoaded = true;

        NotifyDataChanged();
    }


    public void Update()
    {
        NotifyDataChanged();
    }

    private event Action? OnChange;

    private DocContentModel? ContentById(int id)
    {
        foreach (var doc in DocContentModels!)
            if (doc.Id == id)
                return doc;

        return null;
    }

    private void SortSql()
    {
        foreach (var connection in DocConnectionModels)
        {
            ContentById(connection.ParentId)!.DocumentationModels.Add(ContentById(connection.ChildId));
            ContentById(connection.ChildId)!.Parent = ContentById(connection.ParentId);
        }

        foreach (var content in DocContentModels)
            if (content.DocSectionModelId != null)
                foreach (var section in DocSectionModels)
                    if (section.Id == content.DocSectionModelId)
                        section.DocumentationModels.Add(content);

        ByPageOrder();
    }


    private void ByPageOrder()
    {
        DocContentModelsByPageOrder = new List<DocContentModel>();

        var order = 1;
        foreach (var documentation in DocContentModels)
        {
            if (documentation.Parent != null) continue;

            documentation.PageOrder = order++;
            DocContentModelsByPageOrder.Add(documentation);

            void GetAllChildren(DocContentModel docs)
            {
                foreach (var doc in docs.DocumentationModels)
                {
                    doc.PageOrder = order++;
                    DocContentModelsByPageOrder.Add(doc);

                    if (doc.DocumentationModels.Count > 0) GetAllChildren(doc);
                }
            }

            GetAllChildren(documentation);
        }

        DocContentModelsByPageOrder = DocContentModelsByPageOrder.OrderBy(docContent => docContent.PageOrder).ToList();
    }


    private void NotifyDataChanged()
    {
        OnChange?.Invoke();
    }
}