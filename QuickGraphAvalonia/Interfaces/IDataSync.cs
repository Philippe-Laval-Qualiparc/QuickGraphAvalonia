using System.Threading;
using System.Threading.Tasks;

namespace QuickGraphAvalonia.Interfaces;

public interface IDataSync
{
    Task? RunLoopAsync(CancellationToken token);
    Task StopAsync(CancellationToken token);
}