using LocadoraDeVeiculos.Infra.JsonConfigGeral;
using Serilog;
using System;

namespace LocadoraDeVeiculos.Infra.Logger
{
    public static class Serilogger
    {
        public static ILogger Logger;
        static Serilogger()
        {
            var ip = JsonConfig.AppConfig["serverUrl"].ToString();
            var apikey = JsonConfig.AppConfig["apiKey"].ToString();

            Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Seq(ip, apiKey: apikey)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("ApplicationName", "Locadora de Veículos")
                .Enrich.WithProperty("MachineName", Environment.MachineName)
                .Enrich.WithProperty("ApplicationName", Environment.ProcessId)
                .Enrich.WithProperty("ThreadId", Environment.CurrentManagedThreadId)
                .Enrich.WithProperty("UserName", Environment.UserName)
                .CreateLogger();
        }
    }
}
