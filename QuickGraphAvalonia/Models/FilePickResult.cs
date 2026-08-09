using Avalonia.Platform.Storage;

namespace QuickGraphAvalonia.Models;

public record FilePickResult(string Path, IStorageItem? Handle);