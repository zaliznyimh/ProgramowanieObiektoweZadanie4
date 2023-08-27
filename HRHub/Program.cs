using HRHub.Data;
using HRHub.Gui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PeanutButter.TinyEventAggregator;

namespace ImageTagger.FrontEnd.WinForms;

/// <summary>
/// Startimg a programm
/// </summary>
internal static class Program
{
    #region Main Method

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static void Main(string[] args)
    {
        var host = CreateHostBuilder().Build();
        ServiceProvider = host.Services;

        var mainScreen = ServiceProvider.GetRequiredService<MainScreen>();
        mainScreen.Show();
    }

    #endregion // Main Method

    #region Properties And Methods

    /// <summary>
    /// Service provider.
    /// </summary>
    public static IServiceProvider? ServiceProvider { get; private set; } = null;

    /// <summary>
    /// Creates a host builder.
    /// </summary>
    /// <returns> </returns>
    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<IEventAggregator, EventAggregator>();
                services.AddSingleton<MainScreen, MainScreen>();
                services.AddSingleton<ManagerScreen, ManagerScreen>();
                services.AddSingleton<Company, Company>();
                services.AddSingleton<NormalEmployeeScreen, NormalEmployeeScreen>();
            });
    }

    #endregion // Properties And Methods
}