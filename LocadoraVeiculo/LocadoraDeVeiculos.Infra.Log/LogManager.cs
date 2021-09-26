using Serilog;
using Serilog.Core;

namespace LocadoraDeVeiculos.Infra.Log
{
    public static class LogManager
    {
        public static Logger IniciarLog()
        {
            return new LoggerConfiguration().WriteTo.Seq("http://20.195.202.178:5341/").CreateLogger();
        }
    }
}
