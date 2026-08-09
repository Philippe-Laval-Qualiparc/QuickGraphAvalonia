using System;
using System.Runtime.InteropServices.JavaScript;
using CommunityToolkit.Mvvm.ComponentModel;

namespace QuickGraphAvalonia.ViewModels;

public partial class PointerViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _name = String.Empty;
}