

using System.Net.Http.Json;
using Model.Immortal.Notes;
using Model.Work.Git;

#if NO_SQL

#else
using Contexts;
using Microsoft.EntityFrameworkCore;
#endif

namespace Services.Work;

public class NoteService : INoteService {
    private readonly HttpClient httpClient;

    private bool isLoaded;
    
    
    private event Action _onChange;

    private void NotifyDataChanged() {
        _onChange?.Invoke();
    }

    public NoteService(HttpClient httpClient) {
        this.httpClient = httpClient;
    }

    public List<NoteModel> NoteModels { get; set; }


    public void Subscribe(Action action) {
        _onChange += action;
    }

    public void Unsubscribe(Action action) {
        _onChange -= action;
    }

    public bool IsLoaded() {
        return isLoaded;
    }

    

    public async Task Load() {

        if (isLoaded) {
            return;
        }
        
        NoteModels =  (await httpClient.GetFromJsonAsync<NoteModel[]>("generated/NoteModels.json")).ToList();
 

        isLoaded = true;

        NotifyDataChanged();
    }

    
    public void Update() {
        NotifyDataChanged();
    }

}