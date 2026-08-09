using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;
using QuickGraphAvalonia.Models;

namespace QuickGraphAvalonia.Interfaces;

public interface IFileDialogService
{
    Task<IReadOnlyList<FilePickResult>> PickFilesAsync(FilePickerOpenOptions options, CancellationToken ct = default);
    Task<FilePickResult?> SaveFileAsync(FilePickerSaveOptions options, CancellationToken ct = default);
    Task<IReadOnlyList<FilePickResult>> PickFoldersAsync(FolderPickerOpenOptions options, CancellationToken ct = default);
}