using System;
using System.Threading;
using System.Threading.Tasks;
using QuickGraphAvalonia.Interfaces;

namespace QuickGraphAvalonia.Services;

public sealed class DelayProvider : IDelayProvider
{
    public Task Delay(TimeSpan time, CancellationToken ct) => Task.Delay(time, ct);
}