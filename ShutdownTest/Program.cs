using System;
using System.Threading;
using Avalonia;
using Avalonia.Controls;

namespace ShutdownTest;

internal class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        BuildAvaloniaApp().SetupWithClassicDesktopLifetime(args).Instance?.Run(CancellationToken.None);

        //BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
    }
}