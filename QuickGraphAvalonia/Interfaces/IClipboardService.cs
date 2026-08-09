using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace QuickGraphAvalonia.Interfaces;

public interface IClipboardService
{
    Task SetTextAsync(string text);
    Task<string?> GetTextAsync();
    
    // Task SetDataObjectAsync(IDataObject dataObject);
    // Task<IAsyncDataTransfer?> GetDataObjectAsync();
    //
    // Task<IReadOnlyList<string>> GetFormatsAsync();
}