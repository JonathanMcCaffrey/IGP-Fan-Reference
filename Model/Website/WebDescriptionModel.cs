using System.Collections.Generic;
using System.Linq;
using Model.Website.Enums;

namespace Model.Website;

public class WebDescriptionModel
{
    public static readonly List<WebDescriptionModel> List = new();

    public string Name { get; set; } = "Add Name";
    public string Description { get; set; } = "Add description";
    public string Parent { get; set; } = WebSectionType.None;
    public bool IsPrivate { get; set; } = true;

    public static IEnumerable<WebDescriptionModel> GetPages(string forSection)
    {
        return from page in List
            where page.Parent == forSection
            select page;
    }
}