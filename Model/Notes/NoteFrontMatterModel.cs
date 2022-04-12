using System;
using YamlDotNet.Serialization;

namespace Model.Notes;

public class NoteFrontMatterModel
{
    [YamlMember(Alias = "title")] public string Title { get; set; }
    [YamlMember(Alias = "summary")] public string Summary { get; set; }
    [YamlMember(Alias = "created_date")] public DateTime CreatedDate { get; set; }
    [YamlMember(Alias = "updated_date")] public DateTime UpdatedDate { get; set; }
}