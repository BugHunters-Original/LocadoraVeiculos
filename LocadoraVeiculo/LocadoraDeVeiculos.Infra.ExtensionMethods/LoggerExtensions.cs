using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ExtensionMethods
{
    public static class LoggerExtensions
    {
        public static ILogger Aqui(this ILogger logger,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            return logger
                .ForContext("MemberName", memberName)
                .ForContext("ClassName", Path.GetFileNameWithoutExtension(sourceFilePath))
                .ForContext("LineNumber", sourceLineNumber);

        }

        public static void FuncionalidadeUsada(this ILogger logger)
        {
            logger.Information("Funcionalidade Usada");
        }
    }
}
