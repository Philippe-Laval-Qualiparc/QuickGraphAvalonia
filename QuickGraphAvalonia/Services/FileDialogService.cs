using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Dialogs;
using Avalonia.Platform.Storage;
using QuickGraphAvalonia.Interfaces;
using QuickGraphAvalonia.Models;

namespace QuickGraphAvalonia.Services;

public sealed class FileDialogService : IFileDialogService
{
    private readonly TopLevel _topLevel;

    public FileDialogService(TopLevel topLevel) => _topLevel = topLevel;

    public async Task<IReadOnlyList<FilePickResult>> PickFilesAsync(FilePickerOpenOptions options, CancellationToken ct = default)
    {
        var provider = _topLevel.StorageProvider;
        if (provider is { CanOpen: true })
        {
            var files = await provider.OpenFilePickerAsync(options);
            return files.Select(f => new FilePickResult(f.TryGetLocalPath() ?? f.Name, f)).ToArray();
        }

        // if (_topLevel is Window window)
        // {
        //     var dialog = new OpenFileDialog { AllowMultiple = options.AllowMultiple };
        //     var paths = await dialog.ShowManagedAsync(window, new ManagedFileDialogOptions());
        //     return paths.Select(p => new FilePickResult(p, null)).ToArray();
        // }

        return Array.Empty<FilePickResult>();
    }

    public async Task<FilePickResult?> SaveFileAsync(FilePickerSaveOptions options, CancellationToken ct = default)
    {
        var provider = _topLevel.StorageProvider;
        if (provider is { CanSave: true })
        {
            var file = await provider.SaveFilePickerAsync(options);
            return file is null ? null : new FilePickResult(file.TryGetLocalPath() ?? file.Name, file);
        }

        // if (_topLevel is Window window)
        // {
        //     var dialog = new SaveFileDialog
        //     {
        //         DefaultExtension = options.DefaultExtension,
        //         InitialFileName = options.SuggestedFileName
        //     };
        //     var path = await dialog.ShowAsync(window);
        //     return path is null ? null : new FilePickResult(path, null);
        // }

        return null;
    }

    public async Task<IReadOnlyList<FilePickResult>> PickFoldersAsync(FolderPickerOpenOptions options, CancellationToken ct = default)
    {
        var provider = _topLevel.StorageProvider;
        if (provider is { CanPickFolder: true })
        {
            var folders = await provider.OpenFolderPickerAsync(options);
            return folders.Select(f => new FilePickResult(f.TryGetLocalPath() ?? f.Name, f)).ToArray();
        }

        // if (_topLevel is Window window)
        // {
        //     var dialog = new OpenFolderDialog();
        //     var path = await dialog.ShowAsync(window);
        //     return path is null
        //         ? Array.Empty<FilePickResult>()
        //         : new[] { new FilePickResult(path, null) };
        // }

        return Array.Empty<FilePickResult>();
    }
}