using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace LocadoraDeVeiculos.Infra.Log
{
    public static class LogManager
    {
        public static Logger IniciarLog()
        {
            var levelSwitch = new LoggingLevelSwitch(LogEventLevel.Verbose);

            return new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Seq("http://20.195.202.178:5341/")
                .Enrich.FromLogContext()
                .Enrich.WithProperty("ApplicationName", "Locadora de Veículos")
                .Enrich.WithProperty("MachineName", Environment.MachineName)
                .Enrich.WithProperty("ApplicationName", Environment.ProcessId)
                .Enrich.WithProperty("ThreadId", Environment.CurrentManagedThreadId)
                .Enrich.WithProperty("UserName", Environment.UserName)
                .CreateLogger();
        }
        public static ILogger Aqui(this ILogger logger,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            return logger
                .ForContext("MemberName", memberName)
                .ForContext("ClassName", Path.GetFileNameWithoutExtension(sourceFilePath))
                .ForContext("MemberName", sourceLineNumber);
        }

    }
}