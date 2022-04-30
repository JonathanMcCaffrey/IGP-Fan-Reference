using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Blazor.Analytics;
using Blazored.LocalStorage;
using IGP;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Services;
using Services;
using Services.Development;
using Services.Immortal;
using Services.Website;
    

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Logging.SetMinimumLevel(LogLevel.Warning);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");



builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<LazyAssemblyLoader>();

builder.Services.AddProtectedBrowserStorage();

builder.Services.AddLocalization();

builder.Services.AddBlazoredLocalStorageAsSingleton(config =>
{
    config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
    config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
    config.JsonSerializerOptions.WriteIndented = false;
});

#if DEBUG
builder.Services.AddGoogleAnalytics("G-S96LW7TVFY");
#else
builder.Services.AddGoogleAnalytics(builder.Configuration["GATag"]);
#endif

builder.Services.AddScoped<INavigationService, NavigationService>();
builder.Services.AddScoped<IKeyService, KeyService>();
builder.Services.AddScoped<IImmortalSelectionService, ImmortalSelectionService>();
builder.Services.AddScoped<IBuildComparisonService, DeprecatedBuildComparisionService>();
builder.Services.AddScoped<IBuildOrderService, BuildOrderService>();
builder.Services.AddScoped<IEconomyService, EconomyService>();
builder.Services.AddScoped<ITimingService, TimingService>();
builder.Services.AddScoped<IMemoryTesterService, MemoryTesterService>();
builder.Services.AddScoped<IEntityFilterService, EntityFilterService>();
builder.Services.AddScoped<IEntityDisplayService, EntityDisplayService>();
builder.Services.AddScoped<IEntityDialogService, EntityDialogService>();
builder.Services.AddScoped<IToastService, ToastService>();
builder.Services.AddScoped<IWebsiteService, WebsiteService>();
builder.Services.AddScoped<IAgileService, AgileService>();
builder.Services.AddScoped<IGitService, GitService>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<IDocumentationService, DocumentationService>();
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<IVariableService, VariableService>();
builder.Services.AddScoped<IStorageService, StorageService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IEconomyComparisonService, EconomyComparisionService>();
builder.Services.AddScoped<IDataCollectionService, DataCollectionService>();

builder.Services.AddScoped<IDialogService, DialogService>();


builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});


#if NO_SQL

#else
//builder.Services.AddDbContext<DatabaseContext>(options => { options.UseSqlite("Data Source=./Database.db"); });
#endif


await builder.Build().RunAsync();


/**
 Ef Commands


```code
# Create
dotnet ef migrations add InitialCreate
```

```code
# Update
dotnet ef database update
```

```code
# Migrate
dotnet ef migrations add AddBlogCreatedTimestamp
```

```code
# Update
dotnet ef database update
``` 
 */