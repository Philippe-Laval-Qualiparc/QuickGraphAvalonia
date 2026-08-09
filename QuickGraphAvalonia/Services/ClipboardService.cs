using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Input.Platform;
using QuickGraphAvalonia.Interfaces;

namespace QuickGraphAvalonia.Services;

public sealed class ClipboardService : IClipboardService
{
    private readonly TopLevel _topLevel;
    
    public ClipboardService(TopLevel topLevel) => _topLevel = topLevel;

    public Task SetTextAsync(string text) => _topLevel.Clipboard?.SetTextAsync(text) ?? Task.CompletedTask;
    public Task<string?> GetTextAsync() => _topLevel.Clipboard?.TryGetTextAsync() ?? Task.FromResult<string?>(null);
    
    
    //public Task SetDataObjectAsync(IDataObject dataObject) => _topLevel.Clipboard?.SetDataObjectAsync(dataObject) ?? Task.CompletedTask;
    //public Task<IReadOnlyList<string>> GetFormatsAsync() => _topLevel.Clipboard?.GetFormatsAsync() ?? Task.FromResult<IReadOnlyList<string>>(Array.Empty<string>());
    
}