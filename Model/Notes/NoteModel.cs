using System;
using System.Collections.Generic;

namespace Model.Immortal.Notes;

public class NoteModel {
    public int Id { get; set; }
    public DateTime LastUpdated { get; set; }
    public string Name { get; set; }
    public string Section { get; set; }
    public string Description { get; set; }
    public bool IsHidden { get; set; } = false;
    public bool IsPreAlpha { get; set; } = true;

    public string DEPRECATED_Id() {
        return (Section + "-" + Name).ToLower().Replace(" ", "-");
    }
}