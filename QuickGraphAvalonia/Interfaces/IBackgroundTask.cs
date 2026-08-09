using System.Threading;
using System.Threading.Tasks;

namespace QuickGraphAvalonia.Interfaces;

public interface IBackgroundTask
{
    Task StartAsync(CancellationToken token);
    Task StopAsync(CancellationToken token);
}