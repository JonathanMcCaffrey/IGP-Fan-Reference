﻿namespace Model.Website;

public class WebSectionModel {
    public int Id { get; set; }
    public string Name { get; set; } = "Add name";
    public string Description { get; set; } = "Add description";
    public string Href { get; set; } = null;
    public int Order { get; set; } = 0;
    public string IsPrivate { get; set; } = "True";
}