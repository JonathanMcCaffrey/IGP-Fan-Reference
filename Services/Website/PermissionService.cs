using Blazored.LocalStorage;
using Microsoft.JSInterop;

namespace Services.Website;

public class PermissionService : IPermissionService
{
    private bool isLoaded;
    
    
    private IJSRuntime _jsRuntime;
    private bool isStorageEnabled = false;
    private IToastService _toastService;
    private IStorageService _storageService; 

    public PermissionService(IJSRuntime jsRuntime, IToastService toastService, IStorageService storageService)
    {
        _jsRuntime = jsRuntime;
        _toastService = toastService;
        _storageService = storageService;
    }

    public void Subscribe(Action action)
    {
        OnChange += action;
    }

    public void Unsubscribe(Action action)
    {
        OnChange += action;
    }

    public bool GetIsStorageEnabled()
    {
        return _storageService.GetValue<bool>(StorageKeys.EnabledStorage);
    }

    public bool GetIsDataCollectionEnabled()
    {
        return _storageService.GetValue<bool>(StorageKeys.EnabledDataCollection);
    }

    public void SetIsStorageEnabled(bool isEnabled)
    {
        _storageService.SetValue(StorageKeys.EnabledStorage, isEnabled);
    }

    public void SetIsDataCollectionEnabled(bool isEnabled)
    {
        _storageService.SetValue(StorageKeys.EnabledDataCollection, isEnabled);
    }

    public Task Load()
    {
        throw new NotImplementedException();
    }

    private event Action OnChange = null!;

    private void NotifyDataChanged()
    {
        OnChange();
    }
}