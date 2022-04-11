using System.Net.Http.Json;
using Model.Doc;

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


#if DEBUG
        AddTestCode();
#endif

        //TODO Until SQL work in production. Or, why even add SQL?
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
        {
            if (content.DocSectionModelId != null)
            {
                foreach (var section in DocSectionModels)
                {
                    if (section.Id == content.DocSectionModelId)
                    {
                        section.DocumentationModels.Add(content);
                    }
                }
            }
        }
        
        ByPageOrder();
    }

    
    private void ByPageOrder()
    {
        DocContentModelsByPageOrder = new List<DocContentModel>();

        int order = 1;
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


    private void AddTestCode()
    {
        DocContentModels.Add(new DocContentModel
        {
            Id = -110, Name = "Root Parent", Href = "root-parent", CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now, Content = "Example root parent"
        });
        DocContentModels.Add(new DocContentModel
        {
            Id = -109, Name = "Child Parent", Href = "child-parent", CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now, Content = "Example child parent"
        });
        DocContentModels.Add(new DocContentModel
        {
            Id = -108, Name = "Child Child 2", Href = "child-child", CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now, Content = "Example child child"
        });
        DocContentModels.Add(new DocContentModel
        {
            Id = -107, Name = "A", Href = "A", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Content = "A"
        });
        DocContentModels.Add(new DocContentModel
        {
            Id = -106, Name = "B", Href = "B", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, Content = "B"
        });

        DocConnectionModels.Add(new DocConnectionModel { Id = -110, ParentId = -110, ChildId = -109 });
        DocConnectionModels.Add(new DocConnectionModel { Id = -109, ParentId = -109, ChildId = -108 });
        DocConnectionModels.Add(new DocConnectionModel { Id = -108, ParentId = -108, ChildId = -106 });
        DocConnectionModels.Add(new DocConnectionModel { Id = -107, ParentId = -108, ChildId = -107 });
    }


    private void NotifyDataChanged()
    {
        OnChange?.Invoke();
    }
}