namespace MigrationTool;

using Microsoft.Extensions.DependencyInjection;
using MigrationTool.Services;

public static class Program
{
    public static IServiceProvider ServiceProvider { get; set; } = default!;

    static void ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddSingleton<StateManager>();

        ServiceProvider = services.BuildServiceProvider();
    }

    [STAThread]
    static void Main()
    {
        ConfigureServices();
        ApplicationConfiguration.Initialize();
        Application.Run(new MainWindow());
    }
}