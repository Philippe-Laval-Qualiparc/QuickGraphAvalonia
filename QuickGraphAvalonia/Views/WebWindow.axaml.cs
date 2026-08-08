using System;
using System.Diagnostics;
using System.Net;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;

namespace QuickGraphAvalonia.Views;

public partial class WebWindow : Window
{
    public WebWindow()
    {
        InitializeComponent();
        
        WebView.EnvironmentRequested += (sender1, args) =>
        {
            // Enable developer tools for all platforms
            args.EnableDevTools = true;
    
            // Platform-specific configuration
            switch (args)
            {
                case WindowsWebView2EnvironmentRequestedEventArgs webView2Args:
                    webView2Args.IsInPrivateModeEnabled = true;
                    webView2Args.AllowSingleSignOnUsingOSPrimaryAccount = true;
                    break;
                case AppleWKWebViewEnvironmentRequestedEventArgs appleArgs:
                    appleArgs.NonPersistentDataStore = true;
                    appleArgs.ApplicationNameForUserAgent = "QuickGraphAvalonia";
                    break;
                case GtkWebViewEnvironmentRequestedEventArgs gtkArgs:
                    gtkArgs.EphemeralDataManager = true;
                    gtkArgs.ApplicationNameForUserAgent = "QuickGraphAvalonia";
                    break;
            }
        };
    }

    private async void NativeWebView_OnNavigationCompleted(object? sender, WebViewNavigationCompletedEventArgs e)
    {
        // Execute JavaScript
        //await WebView.InvokeScript("alert('Hello World')");
        //await ((NativeWebView)sender!).InvokeScript(" alert('Hello World') ");
    
        await ((NativeWebView)sender!).InvokeScript(""" invokeCSharpAction("{'key': 10}") """);
    }
    
    private void NativeWebView_OnWebMessageReceived(object? sender, WebMessageReceivedEventArgs e)
    {
        var message = e.Body;
        // message == "{'key': 10}"
        
        var commandManager = WebView.TryGetCommandManager();
        if (commandManager != null)
        {
            //commandManager.SelectAll();
            
            // Copy selected content
            commandManager.Copy();
            
        }
    }
    
    /*
     *
      var cookieManager = WebView.TryGetCookieManager();
              if (cookieManager != null)
              {
                  // add a cookie
                  cookieManager.AddOrUpdateCookie(new Cookie()
                  {
                      Name = "test",
                      Value = "value",
                      Domain = "localhost",
                  });
              }
     */
    private async void LoadHandler(object? sender, RoutedEventArgs e)
    {
        try
        {
            var cookieManager = WebView.TryGetCookieManager();
            if (cookieManager != null)
            {
                // Get all cookies
                var cookies = await cookieManager.GetCookiesAsync();
                foreach (var cookie in cookies)
                {
                    Debug.WriteLine($"{cookie.Name} {cookie.Value}");
                }
                
                // update a cookie
                cookieManager.AddOrUpdateCookie(new Cookie()
                {
                    Name = "test",
                    Value = "value2",
                    Domain = "localhost",
                });
            }
        }
        catch (Exception exception)
        {
           Debug.WriteLine(exception); 
        }
    }
}