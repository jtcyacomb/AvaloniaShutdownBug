using System;
using System.Threading;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace ShutdownTest;

internal class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        var instance = BuildAvaloniaApp().SetupWithClassicDesktopLifetime(args).Instance;

        if (instance?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow?.Show();
        }

        instance?.Run(CancellationToken.None);
    }

    public static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
    }
}