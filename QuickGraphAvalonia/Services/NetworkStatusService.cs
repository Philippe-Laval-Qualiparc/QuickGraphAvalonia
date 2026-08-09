using System;
using System.Net.NetworkInformation;
using System.Reactive.Linq;
using QuickGraphAvalonia.Interfaces;

namespace QuickGraphAvalonia.Services;

public sealed class NetworkStatusService : INetworkStatusService
{
    public IObservable<bool> ConnectivityChanges { get; }

    public NetworkStatusService()
    {
        ConnectivityChanges = Observable
            .FromEventPattern<NetworkAvailabilityChangedEventHandler, NetworkAvailabilityEventArgs>(
                handler => NetworkChange.NetworkAvailabilityChanged += handler,
                handler => NetworkChange.NetworkAvailabilityChanged -= handler)
            .Select(args => args.EventArgs.IsAvailable)
            .StartWith(NetworkInterface.GetIsNetworkAvailable());
    }
}