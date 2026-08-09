using System;
using System.Threading;
using System.Threading.Tasks;

namespace QuickGraphAvalonia.Interfaces;

public interface IDelayProvider
{
    Task Delay(TimeSpan time, CancellationToken ct);
}