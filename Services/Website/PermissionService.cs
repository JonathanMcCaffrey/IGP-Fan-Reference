using Microsoft.JSInterop;

namespace Services.Website;

public class PermissionService : IPermissionService, IDisposable
{
    private readonly IStorageService _storageService;
    private IJSRuntime _jsRuntime;
    private IToastService _toastService;
    private bool isLoaded;
    private bool isStorageEnabled = false;

    public PermissionService(IJSRuntime jsRuntime, IToastService toastService, IStorageService storageService)
    {
        _jsRuntime = jsRuntime;
        _toastService = toastService;
        _storageService = storageService;

        _storageService.Subscribe(NotifyDataChanged);
    }

    void IDisposable.Dispose()
    {
        _storageService.Unsubscribe(NotifyDataChanged);
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

    private event Action OnChange = null!;

    private void NotifyDataChanged()
    {
        OnChange();
    }
}