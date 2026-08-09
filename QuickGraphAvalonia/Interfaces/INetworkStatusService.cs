using System;

namespace QuickGraphAvalonia.Interfaces;

public interface INetworkStatusService
{
    IObservable<bool> ConnectivityChanges { get; }
}