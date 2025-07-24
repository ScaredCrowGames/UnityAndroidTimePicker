# Android native Time Picker for Unity

## Table of Contents
- [Installation](#installation)
- [How to use](#how-to-use)
- [Contact us](#contact-us)

## Installation

1. Use the Package Manager:

Window > Package Manager > Install package from git URL...
```link
https://github.com/scaredcrowgames/androidtimepicker.git?path=src
```

2. Or add this to your Unity project's `Packages/manifest.json`:

```json
"com.scaredcrowgames.androidtimepicker": "https://github.com/scaredcrowgames/androidtimepicker.git?path=src"
```
3. Get it from [Unity Asset Store](https://assetstore.unity.com/packages/slug/327347)

## How to use

```csharp
public class TimePickerrDemo : MonoBehaviour
{
    private ITimePicker _timePicker;

    private void Start()
    {
#if UNITY_EDITOR
        _timePicker = new UnityEditorTimePicker();
#elif UNITY_ANDROID
        _timePicker = new AndroidTimePicker();
#endif
        _timePicker?.Show(DateTime.Now.TimeOfDay, OnTimeSelected);
    }

    private void OnTimeSelected(TimeSpan value)
    {
        var formattedTime = value.ToString(@"hh\:mm");
        Debug.Log($"Time selected: {formattedTime}");
    }
}

#if UNITY_EDITOR
class UnityEditorTimePicker : ITimePicker
{
    public void Show(TimeSpan initTime, Action<TimeSpan> callback)
    {
        callback?.Invoke(initTime);
    }
}
#endif
```
> [!TIP]
> 📁 Samples/ contains TimePickerDemo.unity

## Contact us
> [!TIP]
> All discussions, requests and bug reports can be left in the corresponding [Discord channel](https://discord.gg/aQt9aEwsMk) or here in Discussions
