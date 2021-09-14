using log4net;
using log4net.Config;
using System.IO;
using System.Reflection;

namespace LocadoraDeVeiculos.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            var _log4net = LogManager.GetLogger("Cadastro de Cliente");

            _log4net.Info("Hello Logging World");
        }
    }
}
