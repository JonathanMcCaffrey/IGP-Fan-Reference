using System.Collections.Generic;

namespace Model.Hotkeys;

public class HotkeyModel
{
    public static readonly string[] KeyGroups = { "Z", "1", "2", "TAB", "CONTROL", "SHIFT", "C" };
    public static readonly string[] HotKeys = { "`", "Q", "W", "E", "R", "A", "S", "F", "X", "V", "CAPSLOCK" };
    public string KeyText { get; set; }
    public KeyType KeyType { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public bool IsHidden { get; set; }

    public string GetColor()
    {
        return KeyType == KeyType.Action ? "#404146"
            : KeyType == KeyType.Cancel ? "#621b1b"
            : KeyType == KeyType.ControlGroup ? "#443512"
            : KeyType == KeyType.Advance ? "#23262c"
            : KeyType == KeyType.Economy ? "#262c23"
            : KeyType == KeyType.Pyre ? "#440e2c"
            : "#37393F";
    }

    public static List<HotkeyModel> GetAll()
    {
        return new List<HotkeyModel>
        {
            new()
            {
                KeyText = "Z",
                KeyType = KeyType.ControlGroup,
                PositionX = 0,
                PositionY = 0
            },
            new()
            {
                KeyText = "D",
                KeyType = KeyType.ControlGroup,
                PositionX = 1,
                PositionY = 0
            },
            new()
            {
                KeyText = "C",
                KeyType = KeyType.ControlGroup,
                PositionX = 2,
                PositionY = 0
            },
            new()
            {
                KeyText = "V",
                KeyType = KeyType.Pyre,
                PositionX = 3,
                PositionY = 0
            },
            new()
            {
                KeyText = "TAB",
                KeyType = KeyType.ControlGroup,
                PositionX = 4,
                PositionY = 0
            },


            new()
            {
                KeyText = "`",
                KeyType = KeyType.Cancel,
                PositionX = 0,
                PositionY = 1
            },

            new()
            {
                KeyText = "Q",
                KeyType = KeyType.Action,
                PositionX = 1,
                PositionY = 1
            },
            new()
            {
                KeyText = "W",
                KeyType = KeyType.Action,
                PositionX = 2,
                PositionY = 1
            },
            new()
            {
                KeyText = "E",
                KeyType = KeyType.Action,
                PositionX = 3,
                PositionY = 1
            },
            new()
            {
                KeyText = "R",
                KeyType = KeyType.Action,
                PositionX = 4,
                PositionY = 1
            },

            new()
            {
                KeyText = "CAPSLOCK",
                KeyType = KeyType.Action,
                PositionX = 0,
                PositionY = 2
            },

            new()
            {
                KeyText = "A",
                KeyType = KeyType.Action,
                PositionX = 1,
                PositionY = 2
            },
            new()
            {
                KeyText = "S",
                KeyType = KeyType.Action,
                PositionX = 2,
                PositionY = 2
            },
            new()
            {
                KeyText = "D",
                KeyType = KeyType.ControlGroup,
                PositionX = 3,
                PositionY = 2
            },

            new()
            {
                KeyText = "F",
                KeyType = KeyType.Action,
                PositionX = 4,
                PositionY = 2
            },
            new()
            {
                KeyText = "SPACE",
                KeyType = KeyType.Advance,
                PositionX = 1,
                PositionY = 3
            },
            // Economy
            new()
            {
                KeyText = "SHIFT", //TODO Update when game changes
                KeyType = KeyType.Economy,
                PositionX = 0,
                PositionY = 3
            },
            // Pyre
            new()
            {
                KeyText = "ALT",
                KeyType = KeyType.Economy,
                PositionX = 1,
                PositionY = 5,
                IsHidden = true
            },

            // Morphs
            new()
            {
                KeyText = "CONTROL",
                KeyType = KeyType.Economy,
                PositionX = 0,
                PositionY = 4
            }
        };
    }
}