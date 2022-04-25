using Blazored.LocalStorage;
using Model.Feedback;

namespace Services.Website;

public class StorageKeys
{
    public static string EnabledStorage = "StorageEnabled";
    public static string EnabledDataCollection = "StorageDataCollection";
    public static string IsPlainView { get; set; } = "IsPlainView";
    public static string IsDynamicFormatting { get; set; } = "IsDynamicFormatting";
    public static string AttackTime { get; set; } = "AttackTime";
    public static string TravelTime { get; set; } = "TravelTime";
    public static string SelectedFaction { get; set; } = "SelectedFaction";
    public static string SelectedImmortal { get; set; } = "SelectedImmortal";
    public static string BuildInputDelay { get; set; } = "BuildInputDelay";
    public static string WaitTime { get; set; } = "WaitTime";

    public static string WaitTo { get; set; } = "WaitTo";
}

public class StorageService : IStorageService
{
    private readonly ISyncLocalStorageService _localStorageService;
    private readonly IToastService _toastService;
    private bool isLoaded;


    public StorageService(IToastService toastService,
        ISyncLocalStorageService localStorageService)
    {
        _toastService = toastService;
        _localStorageService = localStorageService;
    }

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
            
            _toastService.AddToast(new ToastModel
            {
                Title = "Test 1",
                SeverityType = SeverityType.Error,
                Message = "Storage must be enabled before Storage can be used."
            });
            
            return;
        }

        if (key.Equals(StorageKeys.EnabledStorage))
        {
            _localStorageService.Clear();
            
            _toastService.AddToast(new ToastModel
            {
                Title = "Test 2",
                SeverityType = SeverityType.Error,
                Message = "Storage must be enabled before Storage can be used."
            });
            
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

    public Task Load()
    {
        if (!isLoaded) return Task.CompletedTask;


        isLoaded = true;

        NotifyDataChanged();
        return Task.CompletedTask;
    }

    private event Action OnChange = null!;
    private void NotifyDataChanged()
    {
        OnChange();
    }
}