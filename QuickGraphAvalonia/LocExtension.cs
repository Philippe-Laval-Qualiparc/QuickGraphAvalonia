using System;

namespace QuickGraphAvalonia;

// https://docs.avaloniaui.net/docs/data-binding/markup-extensions
// <TextBlock Text="{local:Loc Key=WelcomeMessage}" />

public class LocExtension
{
    public string Key { get; set; } = "";

    public string ProvideValue(IServiceProvider serviceProvider)
    {
        // Simplified localization lookup
        return LocalizationService.GetString(Key) ?? Key;
    }
}

public static class LocalizationService
{
    public static string GetString(string key)
    {
        return key;
    }
}