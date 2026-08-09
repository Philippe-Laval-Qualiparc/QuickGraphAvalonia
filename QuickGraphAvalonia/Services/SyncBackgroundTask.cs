using System.Threading;
using System.Threading.Tasks;
using QuickGraphAvalonia.Interfaces;

namespace QuickGraphAvalonia.Services;

public sealed class SyncBackgroundTask : IBackgroundTask
{
    private readonly IDataSync _sync;
    
    public SyncBackgroundTask(IDataSync sync) => _sync = sync;

    public Task StartAsync(CancellationToken token)
        => Task.Run(() => _sync.RunLoopAsync(token), token);

    public Task StopAsync(CancellationToken token)
        => _sync.StopAsync(token);
}