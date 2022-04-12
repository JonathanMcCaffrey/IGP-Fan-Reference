---
title: Project Data
summary: Using data in this project.
created_date: 2022-04-11
updated_date: 2022-04-11
---

# Overview

This document will contain general information on data in this project.

## General Note

This project is a work in progress. As such, most of the data in the website doesn't follow the document. Ideally, this will be fixed over time.

## SQL

Relational data is stored in a local SQL database.

This data is converted into JSON so it can be handled by Blazor WASM.

<i>Currently, Blazor WASM has a bug that prevents SQL from being used in production. Although, given SQL doesn't seem to provide much, aside from increased build times and load times, it might just be best to use the design principals of SQL, and it's interface, without using the actual technology in production.</i>

The data is then loaded in by a Service, via it's load method.

```csharp
// Using Component
protected override async Task OnInitializedAsync()
{
    await AgileService.Load();
}
```

```csharp
// Loading Service
public async Task Load()
{
    if (isLoaded) return;
    AgileSprintModels =
        (await httpClient.GetFromJsonAsync<AgileSprintModel[]>("generated/AgileSprintModels.json")
         ?? Array.Empty<AgileSprintModel>()).ToList();
    AgileTaskModels =
        (await httpClient.GetFromJsonAsync<AgileTaskModel[]>("generated/AgileTaskModels.json")
         ?? Array.Empty<AgileTaskModel>()).ToList();
    SortSql();
    isLoaded = true;
    NotifyDataChanged();
}
```

We create a `SortSql()` method to handle adjusting the data to match what SQL would of given us.

```csharp
private void SortSql()
{
    foreach (var agileTask in AgileTaskModels!)
    {
        if (agileTask.AgileSprintModelId != null)
        {
            SprintById(agileTask.AgileSprintModelId.Value)?.AgileTaskModels.Add(agileTask);
        }
    }
}
```

We could also create indexes, or whatever other functionality we lose by SQL not working in production.

Then it's only a matter of using said data.

```csharp
@if (!agileService.IsLoaded())
{
    <LoadingComponent/>
}
else
{
    <LayoutMediumContentComponent>
        <WebsiteTitleComponent>Agile</WebsiteTitleComponent>
        <div class="agileViewContainer">
            @foreach (var sprint in agileService.AgileSprintModels!
                .OrderBy(e => e.EndDate).Reverse())
            {
                <details class="sprintDisplayContainer @sprint.GetSprintType().ToLower()"
                         open="@(sprint.GetSprintType() == SprintType.Current)">
                    <summary class="sprintSummary">
                        <div class="sprintTitle">@sprint.Name</div>
```

## Localized Strings

Localized strings are handled in the Localizations.resx file.

Most text isn't using localized strings yet. And English is the only plan of support in the short term, and probably in the long term as well.

## Markdown Files

Documents and Notes are markdown files located in the `wwwroot/content` folder.

Navigation to these pages is handled via the SQL data. 