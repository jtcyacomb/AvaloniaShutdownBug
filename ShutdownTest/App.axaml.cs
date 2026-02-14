using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ShutdownTest.Views;

namespace ShutdownTest;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();

            desktop.ShutdownRequested += (_, args) =>
            {
                // On Windows, this prevents the app shutting down when closing the window with the title
                // bar 'x' button, `Alt` + `F4`, and the context menu for the app from the task bar.
                // On macOS, this prevents the app shutting down when closing the window with the red window button,
                // and when closing the app with the menu bar.
                // On macOS, when closing the app with the context menu for the app from the dock,
                // this handler is called twice but cancelling shutdown does not work.
                args.Cancel = true;
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}