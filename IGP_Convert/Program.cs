using System.Text.Json;
using Contexts;
using Microsoft.EntityFrameworkCore;

var webProjectName = "IGP";
var projectPath = $"{Environment.CurrentDirectory}/../../../..";
var webPath = $"{projectPath}/{webProjectName}/wwwroot/generated";

var options = new DbContextOptionsBuilder<DatabaseContext>();
options.UseSqlite($"Filename={projectPath}/{webProjectName}/Database.db");

// Load our database
using (var db = new DatabaseContext(options.Options)) {
    // And save data in format Blazor Wasm can use
    File.WriteAllTextAsync($"{webPath}/PatchModels.json", JsonSerializer.Serialize(db.PatchModels));
    File.WriteAllTextAsync($"{webPath}/ChangeModels.json", JsonSerializer.Serialize(db.ChangeModels));
    File.WriteAllTextAsync($"{webPath}/SprintModels.json", JsonSerializer.Serialize(db.SprintModels));
    File.WriteAllTextAsync($"{webPath}/TaskModels.json", JsonSerializer.Serialize(db.TaskModels));
    File.WriteAllTextAsync($"{webPath}/WebSectionModels.json", JsonSerializer.Serialize(db.WebSectionModels));
    File.WriteAllTextAsync($"{webPath}/WebPageModels.json", JsonSerializer.Serialize(db.WebPageModels));
}