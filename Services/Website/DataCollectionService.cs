﻿using Blazor.Analytics;

namespace Services.Website;

public class DataCollectionKeys
{
    // Inputs people are using in the build calculator
    public static string BuildCalcInput = "buildcalc-input";
    public static string PageInitialized = "page-initialized";
    public static string FirstPage = "first-page";
}

public class DataCollectionService : IDataCollectionService, IDisposable
{
    private readonly IAnalytics _globalTracking;
    private readonly IStorageService _storageService;

    private bool _isEnabled;

    public DataCollectionService(IAnalytics globalTracking,
        IStorageService storageService)
    {
        _globalTracking = globalTracking;
        _storageService = storageService;

        _storageService.Subscribe(Refresh);

        Refresh();
    }

    public void SendEvent<T>(string eventName, T eventData)
    {
        if (_isEnabled) _globalTracking.TrackEvent(eventName, eventData);
    }

    void IDisposable.Dispose()
    {
        _storageService.Unsubscribe(Refresh);
    }

    private void Refresh()
    {
        _isEnabled = _storageService.GetValue<bool>(StorageKeys.EnabledDataCollection);
    }
}