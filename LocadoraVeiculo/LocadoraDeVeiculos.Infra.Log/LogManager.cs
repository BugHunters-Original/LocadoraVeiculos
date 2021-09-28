using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using System;
using System.IO;

namespace LocadoraDeVeiculos.Infra.Log
{
    public static class LogManager
    {
        public static Logger IniciarLog()
        {
            var configuration = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json", false, true)
                         .Build();

            var levelSwitch = new LoggingLevelSwitch();

            return new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .MinimumLevel.ControlledBy(levelSwitch)
                .WriteTo.Seq("http://20.195.202.178:5341/", controlLevelSwitch: levelSwitch)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("ApplicationName", "Locadora de Veículos")
                .Enrich.WithProperty("MachineName", Environment.MachineName)
                .Enrich.WithProperty("ProcessId", Environment.ProcessId)
                .Enrich.WithProperty("ThreadId", Environment.CurrentManagedThreadId)
                .Enrich.WithProperty("UserName", Environment.UserName)
                .CreateLogger();
        }
    }
}