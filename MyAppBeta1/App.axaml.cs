using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace MyAppBeta1;

public partial class App : Application
{
    public App()
    {
        System.AppDomain.CurrentDomain.UnhandledException += App_UnhandledException;
    }
    
    private void App_UnhandledException(object sender, System.UnhandledExceptionEventArgs e)
    {
        if (e.ExceptionObject is System.Exception ex)
        {
            System.IO.File.WriteAllText("error.txt", $"error: {ex.Message}\n{ex.StackTrace}");
        }
        else
        {
            System.IO.File.WriteAllText("error.txt", e.ExceptionObject.ToString());
        }
    }
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
}