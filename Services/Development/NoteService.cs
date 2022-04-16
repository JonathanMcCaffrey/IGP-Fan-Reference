using System.Net.Http.Json;
using Model.Notes;

namespace Services.Development;

public class NoteService : INoteService
{
    private readonly HttpClient httpClient;

    private bool isLoaded;

    public NoteService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public List<NoteContentModel> NoteContentModelsByPageOrder { get; set; } = new();

    public List<NoteContentModel> NoteContentModels { get; set; } = default!;
    public List<NoteConnectionModel> NoteConnectionModels { get; set; } = null!;
    public List<NoteSectionModel> NoteSectionModels { get; set; } = null!;


    public void Subscribe(Action action)
    {
        OnChange += action;
    }

    public void Unsubscribe(Action action)
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

        NoteContentModels =
            (await httpClient.GetFromJsonAsync<NoteContentModel[]>("generated/NoteContentModels.json") ??
             Array.Empty<NoteContentModel>()).ToList();
        NoteConnectionModels =
            (await httpClient.GetFromJsonAsync<NoteConnectionModel[]>("generated/NoteConnectionModels.json") ??
             Array.Empty<NoteConnectionModel>()).ToList();
        NoteSectionModels =
            (await httpClient.GetFromJsonAsync<NoteSectionModel[]>("generated/NoteSectionModels.json") ??
             Array.Empty<NoteSectionModel>()).ToList();

        isLoaded = true;

        SortSQL();

        NotifyDataChanged();
    }

    public void Update()
    {
        NotifyDataChanged();
    }


    private event Action OnChange = default!;

    private void NotifyDataChanged()
    {
        OnChange?.Invoke();
    }

    private NoteContentModel? ContentById(int id)
    {
        foreach (var data in NoteContentModels!)
            if (data.Id == id)
                return data;

        return null;
    }

    private void SortSQL()
    {
        foreach (var connection in NoteConnectionModels)
        {
            ContentById(connection.ParentId)!.NoteContentModels.Add(ContentById(connection.ChildId));
            ContentById(connection.ChildId)!.Parent = ContentById(connection.ParentId);
        }

        foreach (var content in NoteContentModels)
            if (content.NoteSectionModelId != null)
                foreach (var section in NoteSectionModels)
                    if (section.Id == content.NoteSectionModelId)
                        section.NoteContentModels.Add(content);

        ByPageOrder();
    }

    private void ByPageOrder()
    {
        NoteContentModelsByPageOrder = new List<NoteContentModel>();

        var order = 1;
        foreach (var note in NoteContentModels)
        {
            if (note.Parent != null) continue;

            note.PageOrder = order++;
            NoteContentModelsByPageOrder.Add(note);

            void GetAllChildren(NoteContentModel docs)
            {
                foreach (var doc in docs.NoteContentModels)
                {
                    doc.PageOrder = order++;
                    NoteContentModelsByPageOrder.Add(doc);

                    if (doc.NoteContentModels.Count > 0) GetAllChildren(doc);
                }
            }

            GetAllChildren(note);
        }

        NoteContentModelsByPageOrder =
            NoteContentModelsByPageOrder.OrderBy(noteContent => noteContent.PageOrder).ToList();
    }
}