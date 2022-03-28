using Model.Immortal.Hotkeys;

namespace Services.Immortal;

public class KeyService : IKeyService {
    private static readonly List<string> _pressedKeys = new();
    private string? _hotkey;
    private string _hotkeyGroup = "C";
    private bool _isHoldingSpace;

    public void Subscribe(Action action) {
        _onChange += action;
    }

    public void Unsubscribe(Action action) {
        _onChange -= action;
    }

    public bool AddPressedKey(string key) {
        _hotkey = null;

        if (_pressedKeys.Count > 0) return false;
        var pressedKey = key.ToUpper();

        if (pressedKey.Equals(" ") || pressedKey.Equals("SPACE")) {
            if (!_isHoldingSpace) {
                _isHoldingSpace = true;
                NotifyDataChanged();
            }

            return false;
        }

        if (!_pressedKeys.Contains(pressedKey)) {
            if (HotkeyModel.KeyGroups.Contains(pressedKey)) _hotkeyGroup = pressedKey;

            if (HotkeyModel.HotKeys.Contains(pressedKey)) _hotkey = pressedKey;

            _pressedKeys.Add(pressedKey);
            NotifyDataChanged();
            return true;
        }

        return false;
    }

    public List<string> GetAllPressedKeys() {
        return _pressedKeys;
    }

    public bool RemovePressedKey(string key) {
        _hotkey = null;

        var pressedKey = key.ToUpper();
        if (pressedKey.Equals(" ") || pressedKey.Equals("SPACE")) {
            if (_isHoldingSpace || true) {
                _isHoldingSpace = false;
                NotifyDataChanged();
            }

            return false;
        }

        if (_pressedKeys.Contains(pressedKey)) {
            _pressedKeys.Remove(pressedKey);
            NotifyDataChanged();
            return true;
        }

        return false;
    }

    public bool IsHoldingSpace() {
        return _isHoldingSpace;
    }

    public string GetHotkey() {
        return _hotkey;
    }

    public string GetHotkeyGroup() {
        return _hotkeyGroup;
    }

    private event Action _onChange;

    private void NotifyDataChanged() {
        _onChange?.Invoke();
    }

    public Action OnChange() {
        return _onChange;
    }
}