using System.Collections.Generic;

namespace Model.Entity.Parts;

public class EntityHotkeyModel : IEntityPartInterface
{
    public string Type { get; set; } = "EntityHotkeyModel";
    public string Hotkey { get; set; }
    public bool HoldSpace { get; set; } = false;
    public string HotkeyGroup { get; set; }


    public bool IsSelectedHotkey(List<string> keys)
    {
        return keys.Contains(Hotkey.ToUpper());
    }

    public bool IsSelectedHotkeyGroup(List<string> keys)
    {
        return keys.Contains(HotkeyGroup.ToUpper());
    }


    public bool IsSelectedHoldSpace(List<string> keys)
    {
        return (keys.Contains("SPACE") || keys.Contains(" ")) == HoldSpace;
    }


    public bool IsSelectedHotkeyGroupWithSpace(List<string> keys)
    {
        var foundKey = false;
        var foundHold = false;
        foreach (var key in keys)
        {
            if (key.ToUpper().Equals(HotkeyGroup.ToUpper())) foundKey = true;
            if (key.ToUpper().Equals("SPACE") || key.ToUpper().Equals(" ")) foundHold = true;
        }

        if (foundKey && foundHold == HoldSpace) return true;

        return false;
    }
}