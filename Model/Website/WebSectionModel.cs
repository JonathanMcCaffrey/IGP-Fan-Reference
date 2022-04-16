using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Website;

public class WebSectionModel
{
    public int Id { get; set; }
    public string Name { get; set; } = "Add name";
    public string Description { get; set; } = "Add description";
    public int Order { get; set; } = 0;
    public string IsPrivate { get; set; } = "True";

    [NotMapped] public List<WebPageModel> WebPageModels { get; set; } = new();
}