
using IGP;
using Microsoft.AspNetCore.Components.Web;

#if NO_SQL

#else
using Contexts;
using Microsoft.EntityFrameworkCore;
#endif

using Services;
using Services.Immortal;
using Services.Website;
using Services.Work;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Logging.SetMinimumLevel(LogLevel.Warning);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


builder.Services.AddSingleton<INavigationService, NavigationService>();
builder.Services.AddSingleton<IKeyService, KeyService>();
builder.Services.AddSingleton<IImmortalSelectionService, ImmortalSelectionService>();
builder.Services.AddSingleton<IBuildComparisonService, BuildComparisionService>();
builder.Services.AddSingleton<IBuildOrderService, BuildOrderService>();
builder.Services.AddSingleton<IEconomyService, EconomyService>();
builder.Services.AddSingleton<ITimingService, TimingService>();
builder.Services.AddSingleton<IMemoryTesterService, MemoryTesterService>();
builder.Services.AddSingleton<IEntityFilterService, EntityFilterService>();

builder.Services.AddSingleton(new HttpClient {
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});


#if NO_SQL

#else
//builder.Services.AddDbContext<DatabaseContext>(options => { options.UseSqlite("Data Source=./Database.db"); });
#endif

builder.Services.AddSingleton<IWebsiteService, WebsiteService>();
builder.Services.AddSingleton<IAgileService, AgileService>();
builder.Services.AddSingleton<IGitService, GitService>();


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