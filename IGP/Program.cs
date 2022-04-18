using System.Globalization;
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

builder.Services.AddLocalization();

builder.Services.AddSingleton<INavigationService, NavigationService>();
builder.Services.AddSingleton<IKeyService, KeyService>();
builder.Services.AddSingleton<IImmortalSelectionService, ImmortalSelectionService>();
builder.Services.AddSingleton<IBuildComparisonService, DeprecatedBuildComparisionService>();
builder.Services.AddSingleton<IBuildOrderService, BuildOrderService>();
builder.Services.AddSingleton<IEconomyService, EconomyService>();
builder.Services.AddSingleton<ITimingService, TimingService>();
builder.Services.AddSingleton<IMemoryTesterService, MemoryTesterService>();
builder.Services.AddSingleton<IEntityFilterService, EntityFilterService>();
builder.Services.AddSingleton<IEntityDisplayService, EntityDisplayService>();
builder.Services.AddSingleton<IEntityDialogService, EntityDialogService>();
builder.Services.AddSingleton<IToastService, ToastService>();
builder.Services.AddSingleton<IWebsiteService, WebsiteService>();
builder.Services.AddSingleton<IAgileService, AgileService>();
builder.Services.AddSingleton<IGitService, GitService>();
builder.Services.AddSingleton<INoteService, NoteService>();
builder.Services.AddSingleton<IDocumentationService, DocumentationService>();
builder.Services.AddSingleton<ISearchService, SearchService>();

builder.Services.AddSingleton<IEconomyComparisonService, EconomyComparisionService>();

builder.Services.AddSingleton(new HttpClient
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