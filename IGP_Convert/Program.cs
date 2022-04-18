using System.Text.Json;
using Contexts;
using Microsoft.EntityFrameworkCore;

var webProjectName = "IGP";
var projectPath = $"{Environment.CurrentDirectory}/../../../..";
var webPath = $"{projectPath}/{webProjectName}/wwwroot/generated";

var options = new DbContextOptionsBuilder<DatabaseContext>();
options.UseSqlite($"Filename={projectPath}/{webProjectName}/Database.db");

// Load our database
using (var db = new DatabaseContext(options.Options))
{
    // And save data in format Blazor Wasm can use
    File.WriteAllTextAsync($"{webPath}/GitPatchModels.json", JsonSerializer.Serialize(db.GitPatchModels));
    File.WriteAllTextAsync($"{webPath}/GitChangeModels.json", JsonSerializer.Serialize(db.GitChangeModels));
    File.WriteAllTextAsync($"{webPath}/AgileSprintModels.json", JsonSerializer.Serialize(db.AgileSprintModels));
    File.WriteAllTextAsync($"{webPath}/AgileTaskModels.json", JsonSerializer.Serialize(db.AgileTaskModels));
    File.WriteAllTextAsync($"{webPath}/WebSectionModels.json", JsonSerializer.Serialize(db.WebSectionModels));
    File.WriteAllTextAsync($"{webPath}/WebPageModels.json", JsonSerializer.Serialize(db.WebPageModels));

    File.WriteAllTextAsync($"{webPath}/DocContentModels.json", JsonSerializer.Serialize(db.DocContentModels));
    File.WriteAllTextAsync($"{webPath}/DocConnectionModels.json", JsonSerializer.Serialize(db.DocConnectionModels));
    File.WriteAllTextAsync($"{webPath}/DocSectionModels.json", JsonSerializer.Serialize(db.DocSectionModels));

    File.WriteAllTextAsync($"{webPath}/NoteContentModels.json", JsonSerializer.Serialize(db.NoteContentModels));
    File.WriteAllTextAsync($"{webPath}/NoteConnectionModels.json", JsonSerializer.Serialize(db.NoteConnectionModels));
    File.WriteAllTextAsync($"{webPath}/NoteSectionModels.json", JsonSerializer.Serialize(db.NoteSectionModels));
    
    File.WriteAllTextAsync($"{webPath}/Variables.json", JsonSerializer.Serialize(db.Variables));
}