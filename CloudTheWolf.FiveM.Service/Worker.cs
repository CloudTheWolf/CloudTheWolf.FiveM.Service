using System.Diagnostics;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;

namespace CloudTheWolf.FiveM.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private static readonly Process FxServer = new Process();
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetOptions();
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await RunFxServer(stoppingToken);
                await Task.Delay(-1, stoppingToken);
            }
        }
        private static void SetOptions()
        {
            var configFile = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "appsettings.json"));
            dynamic config = JToken.Parse(configFile);
            Options.ExePath = config.FXServer.exePath;
            Options.ExeName = config.FXServer.exeName;
            Options.ArgList = config.FXServer.args.ToObject<Dictionary<string, object>>();

        }

        private static async Task RunFxServer(CancellationToken stoppingToken)
        {
            FxServer.StartInfo.FileName = Path.Combine(Options.ExePath,Options.ExeName);
            FxServer.StartInfo.WorkingDirectory = Options.ExePath;
            FxServer.StartInfo.UseShellExecute = false;
            foreach (var arg in Options.ArgList)
            {
                FxServer.StartInfo.Arguments += $"{arg.Key} {arg.Value} ";
            }
            FxServer.Start();
            Console.WriteLine($"FXServer Running with PID: {FxServer.Id}");
            await FxServer.WaitForExitAsync(stoppingToken);
        }
    }
}