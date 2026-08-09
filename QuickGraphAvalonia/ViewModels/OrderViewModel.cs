using System;

namespace QuickGraphAvalonia.ViewModels;

public sealed record OrderViewModel(string Title, decimal Total, DateTime PlacedOn);