using Blazored.LocalStorage;
using Microsoft.JSInterop;
using Model.Feedback;

namespace Services.Website;

public class StorageKeys
{
    public static string EnabledStorage = "StorageEnabled";
    public static string EnabledDataCollection = "StorageDataCollection";
    public static string IsPlainView { get; set; } = "IsPlainView";
}

public class StorageService : IStorageService
{
    private readonly ISyncLocalStorageService _localStorageService;
    private IJSRuntime _jsRuntime;
    private readonly IToastService _toastService;
    private bool isLoaded;
    private bool isStorageEnabled;


    public StorageService(IJSRuntime jsRuntime, IToastService toastService,
        ISyncLocalStorageService localStorageService)
    {
        _jsRuntime = jsRuntime;
        _toastService = toastService;
        _localStorageService = localStorageService;
    }

    private string enabledKey => StorageKeys.EnabledStorage;

    public void Subscribe(Action action)
    {
        OnChange += action;
    }

    public void Unsubscribe(Action action)
    {
        OnChange += action;
    }

    public T GetValue<T>(string forKey)
    {
        return _localStorageService.GetItem<T>(forKey);
    }

    public void SetValue<T>(string key, T value)
    {
        if (key.Equals(StorageKeys.EnabledStorage) && value.Equals(true))
        {
            _localStorageService.SetItem(key, value);
            NotifyDataChanged();
            return;
        }

        if (key.Equals(StorageKeys.EnabledStorage))
        {
            _localStorageService.Clear();
            NotifyDataChanged();
            return;
        }

        var isEnabled = GetValue<bool>(StorageKeys.EnabledStorage);
        if (!isEnabled)
        {
            _toastService.AddToast(new ToastModel
            {
                Title = "Permission Error",
                SeverityType = SeverityType.Error,
                Message = "Storage must be enabled before Storage can be used."
            });
            NotifyDataChanged();
            return;
        }

        _localStorageService.SetItem(key, value);
        NotifyDataChanged();
    }

    public async Task Load()
    {
        if (!isLoaded) return;


        isLoaded = true;

        isStorageEnabled = GetValue<bool>(enabledKey);

        NotifyDataChanged();
    }

    private event Action OnChange = null!;

    private void NotifyDataChanged()
    {
        try
        {

            OnChange();
        }
        catch (Exception e)
        {
        }
    }
}