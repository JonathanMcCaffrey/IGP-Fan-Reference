namespace Model.Website;

public class WebPageModel {
    public int Id { get; set; }
    public int WebSectionModelId { get; set; }
    public string Name { get; set; } = "Add name";
    public string Description { get; set; } = "Add description";
    public string Href { get; set; } = null;
    public string IsPrivate { get; set; } = "True";
}