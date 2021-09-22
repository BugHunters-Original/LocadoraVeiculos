using log4net;
using log4net.Config;
using System.IO;
using System.Reflection;

namespace LocadoraDeVeiculos.Infra.Log
{
    public class Log
    {
        public Log()
        {
            IniciarLog();
        }
        public void IniciarLog()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }
    }
}
