using System;
using System.Diagnostics;
using CloudTheWolf.FiveM.Service;


namespace CloudTheWolf.FiveM.Service 
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;

            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services => { services.AddHostedService<Worker>(); })
                .UseWindowsService()
                .Build();

            await host.RunAsync();
            await host.StopAsync();
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            var processes = Process.GetProcessesByName(Options.ExeName.Replace(".exe", ""));
            foreach (var process in processes)
            {
                process.Kill();
            }
        }
    }
}
